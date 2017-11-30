using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;
using GlmNet;



namespace CGOpenGL2
{ 
    class Program
    {
        //0 - все вокруг сцены 1 - все вокруг центра пьедестала 2 - все вокруг своей оси
        private static int rotateMod = 0;

        static double angle = 0;
        static double angleY = 0;
        static float radius = 5.0f;

        static float camX = glm.sin(0) * radius;
        static float camY = glm.sin(0) * radius; 
        static float camZ = glm.cos(0) * radius;
        static float camUpY = 1;
        static vec3 cameraPos = new vec3(0.0f, 1.0f, 5.0f);
        static vec3 cameraFront = new vec3(0.0f, 0.0f, -1.0f);
        static vec3 cameraUp = new vec3(0.0f, 1.0f, 0.0f);


        private static int width = 800, height = 600;
        private static int rotate_x = 0, rotate_y = 0;
        static float angleXZ = 0.0f, angleYZ = 0.0f, rotationX = 0.0f, rotationY = 0.0f, rotationZ = 0.0f;
        static void Main(string[] args)
        {
			Glut.glutInit();
			Glut.glutInitWindowPosition(100, 100);
			Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Glut.glutInitWindowSize(width, height);
			Glut.glutCreateWindow("OpenGL Less2");
            Init();
            Glut.glutDisplayFunc(DisplayScene);
            Glut.glutIdleFunc(DisplayScene);
            /*Glut.glutDisplayFunc(drawSnowMan);
            Glut.glutIdleFunc(drawSnowMan);*/
            /*Glut.glutDisplayFunc(Test.RenderWireSphere);
            Glut.glutIdleFunc(Test.RenderWireSphere);*/
            /*Glut.glutDisplayFunc(Test.Display);
            Glut.glutIdleFunc(Test.Display);*/
            Glut.glutSpecialFunc(processSpecialKeys);
            Glut.glutKeyboardFunc(processNormalKeys);
            Glut.glutMainLoop();
		}

        private static void Init()
        {
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, width, height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)width / (float)height, 0.1, 400);//angle, aspect, znear, zfar

            Gl.glMatrixMode(Gl.GL_MODELVIEW);         
            //Glu.gluLookAt(0, -1, 5, 0, 0, 0, 0, 1, 0);     

            Gl.glEnable(Gl.GL_LIGHTING);
            
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, Parames.light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, Parames.light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, Parames.light0_specular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, Parames.light0_position);

            /*Gl.glEnable(Gl.GL_LIGHT1);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, Parames.light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, Parames.light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, Parames.light1_specular);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, Parames.light1_position);*/

            /*Gl.glEnable(Gl.GL_LIGHT2);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, Parames.light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, Parames.light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, Parames.light0_specular);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, Parames.light1_position);
            float[] light2_direction = { 0.0f, 0.0f, -1.0f};
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light2_direction);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 180.0f);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 0.0f);*/

            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }

        //сцена пьедестал почета, 3ри кубика
        private static void DisplayScene()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();

            vec3 cameraLook = cameraPos + cameraFront;
            Glu.gluLookAt(cameraPos.x, cameraPos.y, cameraPos.z, cameraLook.x, cameraLook.y, cameraLook.z,
               cameraUp.x, cameraUp.y, cameraUp.z);

            Glu.gluLookAt(camX, camY, camZ, 0.0, 0.0, 0.0, 0.0, camUpY, 0.0);

            if (rotateMod == 0)
            {
                Gl.glRotated(rotate_x, 1.0, 0.0, 0.0);
                Gl.glRotated(rotate_y, 0.0, 1.0, 0.0);
            }
            //бронза
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Parames.mat3_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Parames.mat3_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Parames.mat3_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, Parames.mat3_shiness);
            Gl.glPushMatrix();          
            Gl.glTranslated(1.15f, 0, -4.8f);
            Gl.glRotated(20, 1, 0, 0);
            if (rotateMod > 0)
            {
                if (rotateMod == 1) Gl.glTranslated(0, 0, -4);
                Gl.glRotated(rotate_x, 1.0, 0.0, 0.0);
                Gl.glRotated(rotate_y, 0.0, 1.0, 0.0);
                if (rotateMod == 1) Gl.glTranslated(0, 0, 4);
            }
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            //золото
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Parames.mat1_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Parames.mat1_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Parames.mat1_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, Parames.mat1_shiness);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -4);
            Gl.glRotated(20, 1, 0, 0);
            if (rotateMod > 0)
            {
                if (rotateMod == 1) Gl.glTranslated(0, 0, -4);
                Gl.glRotated(rotate_x, 1.0, 0.0, 0.0);
                Gl.glRotated(rotate_y, 0.0, 1.0, 0.0);
                if (rotateMod == 1) Gl.glTranslated(0, 0, 4);
            }
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            //серебро
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Parames.mat2_amb);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Parames.mat2_dif);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Parames.mat2_spec);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, Parames.mat2_shiness);
            Gl.glPushMatrix();
            Gl.glTranslated(-1.15f, 0, -4.8f);
            Gl.glRotated(20, 1, 0, 0);
            if (rotateMod > 0)
            {
                if (rotateMod == 1) Gl.glTranslated(0, 0, -4);
                Gl.glRotated(rotate_x, 1.0, 0.0, 0.0);
                Gl.glRotated(rotate_y, 0.0, 1.0, 0.0);
                if (rotateMod == 1) Gl.glTranslated(0, 0, 4);
            }
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
            Gl.glFlush();
            Glut.glutSwapBuffers();
        }

        //вращение камеры вокруг обьекта
        private static void processSpecialKeys(int key, int xx, int yy)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_LEFT:
                    angle -= 0.1;
                    camX = glm.sin((float)angle) * radius;
                    camZ = glm.cos((float)angle) * radius;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    angle += 0.1;
                    camX = glm.sin((float)angle) * radius;
                    camZ = glm.cos((float)angle) * radius;
                    break;
                case Glut.GLUT_KEY_UP:
                    angleY += 0.1;
                    if (Math.Sign(camZ) != Math.Sign(glm.cos((float)angleY) * radius)) camUpY *= -1;
                    camY = glm.sin((float)angleY) * radius;
                    camZ = glm.cos((float)angleY) * radius;
                    break;
                case Glut.GLUT_KEY_DOWN:
                    angleY -= 0.1;
                    if (Math.Sign(camZ) != Math.Sign(glm.cos((float)angleY) * radius)) camUpY *= -1;
                    camY = glm.sin((float)angleY) * radius;
                    camZ = glm.cos((float)angleY) * radius;
                    break;
                case Glut.GLUT_KEY_F1: rotateMod = 0; break;
                case Glut.GLUT_KEY_F2: rotateMod = 1; break;
                case Glut.GLUT_KEY_F3: rotateMod = 2; break;
            }
        }


        //движение камеры влево вправо, приближение отдаление
        private static void processNormalKeys(byte keyParam, int xx, int yy)
        {
            var key = (char)keyParam;
            float cameraSpeed = 0.05f;
            switch (key)
            {
                case 'a':
                    cameraPos -= glm.normalize(glm.cross(cameraFront, cameraUp)) * cameraSpeed;
                    angleXZ = (float)(angleXZ + 1) % 360;
                    rotationX = (float)Math.Cos(angleXZ);
                    rotationZ = (float)Math.Sin(angleXZ);
                    break;
                case 'd':
                    cameraPos += glm.normalize(glm.cross(cameraFront, cameraUp)) * cameraSpeed;
                    angleXZ = (float)(angleXZ - 1) % 360;
                    rotationX = (float)Math.Cos(angleXZ);
                    rotationZ = (float)Math.Sin(angleXZ);
                    break;
                case 'w':
                    cameraPos += cameraSpeed * cameraFront;
                    angleYZ = (float)(angleYZ - 0.1);
                    rotationY = (float)Math.Cos(angleYZ);
                    rotationZ = (float)Math.Sin(angleYZ);
                    break;
                case 's':
                    cameraPos -= cameraSpeed * cameraFront;
                    angleYZ = (float)(angleYZ + 0.1);
                    rotationY = (float)Math.Cos(angleYZ);
                    rotationZ = (float)Math.Sin(angleYZ);
                    break;
                case '8': rotate_x += 5; break;
                case '2': rotate_x -= 5; break;
                case '6': rotate_y += 5; break;
                case '4': rotate_y -= 5; break;

            }
        }

        //Рисование снеговика, вокруг которого вращается камера
        static void drawSnowMan()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // установить камеру
            Gl.glLoadIdentity();
            vec3 cameraLook = cameraPos + cameraFront;
            Glu.gluLookAt(cameraPos.x, cameraPos.y, cameraPos.z, cameraLook.x, cameraLook.y, cameraLook.z,
               cameraUp.x, cameraUp.y, cameraUp.z);

            Glu.gluLookAt(camX, camY, camZ, 0.0, 0.0, 0.0, 0.0, camUpY, 0.0);

            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            // тело снеговика
            Gl.glTranslatef(0.0f, 0.75f, 0.0f);
            Glut.glutSolidSphere(0.75f, 20, 20);
            // голова снеговика
            Gl.glTranslatef(0.0f, 1.0f, 0.0f);
            Glut.glutSolidSphere(0.25f, 20, 20);
            // глаза снеговика
            Gl.glPushMatrix();
            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glTranslatef(0.05f, 0.10f, 0.18f);
            Glut.glutSolidSphere(0.05f, 10, 10);
            Gl.glTranslatef(-0.1f, 0.0f, 0.0f);
            Glut.glutSolidSphere(0.05f, 10, 10);
            Gl.glPopMatrix();
            // нос снеговика
            Gl.glColor3f(1.0f, 0.5f, 0.5f);
            Gl.glRotatef(0.0f, 1.0f, 0.0f, 0.0f);
            Glut.glutSolidCone(0.08f, 0.5f, 10, 2);
            //Gl.glPopMatrix();
            Gl.glFlush();
            Glut.glutSwapBuffers();
        }

    }
}
