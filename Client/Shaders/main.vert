#version 330 core

layout(location = 0) in vec3 aPosition;

void main() {
    mat4 view = mat4(
        vec4(.2, 0, 0, 0),
        vec4(0, .2, 0, 0),
        vec4(0, 0, .2, 0),
        vec4(0, 0, 0, 1)
    );
    
    gl_Position = view * vec4(aPosition, 1.0);
}