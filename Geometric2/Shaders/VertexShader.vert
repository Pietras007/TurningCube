#version 330
layout (location = 0) in vec3 a_Position;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

out vec3 FragPos;
out vec3 Normal;
out vec2 TexCoords;

vec3 normalGenerator(vec3 a, vec3 b, vec3 c);
void main()
{
    FragPos = vec3(vec4(a_Position, 1.0) * model);
    Normal = vec3(vec4(aNormal,1.0f)* model);
    TexCoords = aTexCoords;

    gl_Position = vec4(a_Position, 1.0) * model * view * projection;
}