Shader "My Shader" {
    Properties {
        _Point ("point in world space", Vector) = (0,0,0,1)
        _ColorNear ("color near", Color) = (1,0,0,1)
        _ColorFar ("color far", Color) = (0,1,0,1)
    }
    SubShader {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _Point;
            uniform float4 _ColorNear;
            uniform float4 _ColorFar;

            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 col : TEXCOORD0;
            };

            vertOutput vert(float4 vertexPos: POSITION) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(vertexPos * _Point);
                //output.col = vertexPos + float4(0.5, 0.5, 0.5, 0);
                if(vertexPos.z > 0)
                {
                    output.col = _ColorNear;
                }
                else
                {
                    output.col = _ColorFar;
                }
                //output.col = vertexPos + float4(0.5, 0.5, 0.5, 0);
                // x, y, z plus w offset is the float4 input
                //return UnityObjectToClipPos(vertexPos *float4(1,0.5,1,1));
                //return UnityObjectToClipPos(vertexPos * _Point);
                return output;
            }

            float4 frag(vertOutput input) : COLOR {
                //return float4(1.0, 1.0, 0.0, 1.0);
                // red, green, blue, transparency
                // Magenta: 1, 0, 1
                // Yellow: 1, 1, 0
                return input.col;
            }

            ENDCG

        }
    }
}