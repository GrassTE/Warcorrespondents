Shader "MySelf/2DBlur"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BlurRadius("BlurRadius", Range(2, 15)) = 2  
        _TextureSize("TextureSize", Float) = 500
    }
        SubShader
        {
            Tags {"Queue" = "Transparent" "IgnoreProjector" = "true" "RenderType" = "Transparent"}
            ZWrite Off Blend SrcAlpha OneMinusSrcAlpha Cull Off

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _MainTex;
                int _BlurRadius;
                float _TextureSize;
         
                float GetGaussWeight(float x, float y, float sigma)
                {
                    float sigma2 = pow(sigma, 2.0f);        
                    float left = 1 / (2 * sigma2 * 3.1415926f);
                    float right = exp(-(x * x + y * y) / (2 * sigma2));     
                    return left * right;
                }

                fixed4 GaussBlur(float2 uv)        
                {
                   
                    float sigma = (float)_BlurRadius / 3.0f;
                    float4 col = float4(0, 0, 0, 0);
                    for (int x = -_BlurRadius; x <= _BlurRadius; ++x)
                    {
                        for (int y = -_BlurRadius; y <= _BlurRadius; ++y)
                        {
                            float4 color = tex2D(_MainTex, uv + float2(x / _TextureSize, y / _TextureSize));                        
                            float weight = GetGaussWeight(x, y, sigma);                       
                            col += color * weight;    
                        }
                    }
                    return col;
                }

                fixed4 SimpleBlur(float2 uv)
                {
                    float4 col = float4(0, 0, 0, 0);
                    for (int x = -_BlurRadius; x <= _BlurRadius; ++x)
                    {
                        for (int y = -_BlurRadius; y <= _BlurRadius; ++y)
                        {
                            float4 color = tex2D(_MainTex, uv + float2(x / _TextureSize, y / _TextureSize));
                            
                            col += color;
                        }
                    }
                   
                    col = col / pow(_BlurRadius * 2 + 1, 2.0f);
                    return col;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float4 col = GaussBlur(i.uv);
                    //float4 col = SimpleBlur(i.uv);
                    return col;
                }
                ENDCG
            }
        }
        FallBack "Diffuse"
}
