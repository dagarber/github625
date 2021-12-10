Shader "Vertex to Fragment" {
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
            uniform float _DistanceNear;
            uniform float4 _ColorNear;
            uniform float4 _ColorFar;


            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 worldPosition : TEXCOORD0;
            };

            vertOutput vert(float4 vertexPos: POSITION) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(vertexPos);
                output.worldPosition = mul(unity_ObjectToWorld, vertexPos);
                return output;
                // all lines computed for each vertex at the same time
            }

            float4 frag(vertOutput input) : COLOR {
                float dist = distance(input.worldPosition, _Point);
                if(dist < _DistanceNear)
                {
                    return _ColorNear;
                }
                else
                {
                    return _ColorFar;
                }
            }

            ENDCG

        }
    }
}