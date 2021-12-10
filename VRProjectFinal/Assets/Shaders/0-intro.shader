Shader "First Shader" {
    Properties {
        _Point ("point in world space", Vector) = (0,0,0,1)
        _DistanceNear ("threshold distance", Float) = 3.0
        _ColorNear ("color near", Color) = (1,0,0,1)
        _ColorFar ("color far", Color) = (0,1,0,1)
    }
    SubShader {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _Point;

            float4 vert(float4 vertexPos: POSITION) : SV_POSITION {
                // x, y, z plus w offset is the float4 input
                //return UnityObjectToClipPos(vertexPos *float4(1,0.5,1,1));
                return UnityObjectToClipPos(vertexPos * _Point);
            }

            float4 frag(void) : COLOR {
                return float4(1.0, 1.0, 0.0, 1.0);
                // red, green, blue, transparency
                // Magenta: 1, 0, 1
                // Yellow: 1, 1, 0
            }

            ENDCG

        }
    }
}