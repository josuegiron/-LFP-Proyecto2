using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            obtenerXY();
            ir(xActual, yActual);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.CurrentCulture = new System.Globalization.CultureInfo("es");
            escribirEnConsola(" KTurtle> Inicializando...");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtentrada_TextChanged(object sender, EventArgs e)
        {

        }

        //  COMPARAR:

        private Boolean comparar(string[] matrizDeCaracteres, string caracter)
        {
            string caracterStr = caracter.ToString();
            for(int i=0; i < matrizDeCaracteres.Length; i++)
            {
                if(caracterStr == matrizDeCaracteres[i])
                {
                    return true;
                }
            }
            return false;
        }

        


        // AFD***************************************************************************************************

        private void analizarLenguaje(string cadena)
        {
            analizarLexico(cadena);
            analizarSintaxis(cadena);
        }

        private void analizarLexico(string cadena)
        {
            int estadoInicial = 0;
            int estadoActual = 0;
            char caracterActual;
            string lexema = "";

            string[] L = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "\xD1", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "\xF1", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] N = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] R = { "=" };
            string[] PN = { "." };
            string[] P = { ";"};
            string[] D = { "("};
            string[] I = { ")"};
            string[] C = { ","};
            string[] G = { "_" };
            string[] X = { " ", "+", "-", "*", "/", "^" };
            string[] SL = { "\n" };
            string[] CM = { "/" };
            string[] A = { "*" };
            string[] B = { "\"" };

            int colActual = 0, filaActual = 1, fila = 0, columna = 0;

            //  INICIO DE LAS INTERACIONES

            for (estadoInicial = 0; estadoInicial < cadena.Length; estadoInicial++)
            {
                caracterActual = cadena[estadoInicial];
                string caracterActualStr = caracterActual.ToString();

                colActual++;
                //  AFD
                switch (estadoActual)
                {
                    
                    case 0: //  ESTADO 0

                        fila = filaActual;
                        columna = colActual;
                        if (comparar(CM, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 8;
                        }
                        else if (comparar(N, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 1;
                        }
                        else if(comparar(L, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        else if(comparar(P, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 3;
                        }
                        else if (comparar(R, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 4;
                        }
                        else if (comparar(D, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 5;
                        }
                        else if (comparar(I, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 6;
                        }
                        else if (comparar(C, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 7;
                        }
                        else if (comparar(B, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        else
                        {
                            switch (caracterActual)
                            {
                                case ' ':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\r':
                                    estadoActual = 0;
                                    break;
                                case '\n':
                                    filaActual++;
                                    colActual = 0;
                                    estadoActual = 0;
                                    break;
                                default:
                                    
                                    lexema += caracterActual;
                                    estadoActual = -1;
                                    colActual--;
                                    break;
                            }
                            
                        }
                        break;

                    case 1:     //  ESTADO 1
                        if (comparar(N, caracterActualStr))
                        {
                            
                            estadoActual = 1;
                            lexema += caracterActual;
                        }
                        else if (comparar(L, caracterActualStr))
                        {
                            estadoActual = 9;
                            lexema += caracterActual;
                        }
                        else if (comparar(PN, caracterActualStr))
                        {
                            estadoActual = 16;
                            lexema += caracterActual;
                        }
                        else if(!comparar(N, caracterActualStr))
                        {
                            // metodo enviar lexema
                            // ver si es un lexema valido
                            validarLexema(lexema, fila, columna, "numero");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;

                        }
                       

                        break;
                    case 2:     //  ESTADO 2
                        if (comparar(N, caracterActualStr))
                        {

                            estadoActual = 2;
                            lexema += caracterActual;
                        }
                        else if (comparar(L, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        else if (comparar(G, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 2;
                        }
                        else 
                        {
                            // metodo enviar lexema
                            // ver si es un lexema valido
                            validarLexema(lexema, fila, columna, "reservado");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;

                        }
                        break;
                    case 3:     //  ESTADO 3
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 4:     //  ESTADO 4
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 5:     //  ESTADO 5
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 6:     //  ESTADO 6
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 7:     //  ESTADO 7
                        validarLexema(lexema, fila, columna, "reservado");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 8:     //  ESTADO 8
                        if (comparar(CM, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 10;
                        }
                        else if (comparar(A, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        else
                        {
                            switch (caracterActual)
                            {
                                case ' ':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\r':
                                    estadoActual = -1;
                                    break;
                                case '\n':
                                    filaActual++;
                                    colActual = 0;
                                    estadoActual = -1;
                                    break;
                                default:

                                    lexema += caracterActual;
                                    estadoActual = -1;
                                    colActual--;
                                    break;
                            }

                        }
                        break;
                    case 9:     //  ESTADO ERROR

                        if (comparar(L, caracterActualStr))
                        {
                            estadoActual = 9;
                            lexema += caracterActual;
                        }
                        else
                        {
                            
                            agregarError(lexema, fila, columna);
                            escribirEnConsola("- ERROR: No se reconoce el lexema \"" + lexema  + "\" en (Fila: " + fila + ", Col: " + columna + ")");
                           
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;

                        }
                        
                        break;

                    case 10:     //  ESTADO 10
                        if (comparar(SL, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 11;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 10;
                        }
                        break;

                    case 11:     //  ESTADO 11
                        validarLexema(lexema, fila, columna, "comentarioLineal");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual = 0;
                        filaActual++;
                        break;
                    case 12:     //  ESTADO 12
                        if (comparar(A, caracterActualStr))
                        {
                            if(comparar(CM, cadena[estadoInicial + 1].ToString()))
                            {
                                lexema += caracterActual;
                                lexema += cadena[estadoInicial + 1].ToString();
                                estadoActual = 13;
                                estadoInicial++;
                            }
                            else 
                            {
                                lexema += caracterActual;
                                estadoActual = 12;
                            }
                        }
                        else if (comparar(SL, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                            filaActual++;
                            colActual = 0;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 12;
                        }
                        break;

                    case 13:     //  ESTADO 13
                        validarLexema(lexema, fila, columna, "comentarioMultilinea");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 14:     //  ESTADO 14
                        if (comparar(B, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 15;
                        }
                        else
                        {
                            lexema += caracterActual;
                            estadoActual = 14;
                        }
                        break;

                    case 15:     //  ESTADO 15
                        validarLexema(lexema, fila, columna, "cadena");
                        estadoActual = 0;
                        lexema = "";
                        estadoInicial--;
                        colActual--;
                        break;
                    case 16:     //  ESTADO 16
                        if (comparar(N, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 17;
                        }
                        else
                        {
                            switch (caracterActual)
                            {
                                case ' ':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\r':
                                    estadoActual = -1;
                                    break;
                                case '\n':
                                    filaActual++;
                                    colActual = 0;
                                    estadoActual = -1;
                                    break;
                                default:

                                    lexema += caracterActual;
                                    estadoActual = -1;
                                    colActual--;
                                    break;
                            }
                        }
                        
                        break;
                    case 17:     //  ESTADO 17
                        if (comparar(N, caracterActualStr))
                        {
                            lexema += caracterActual;
                            estadoActual = 17;
                        }
                        else
                        {
                            validarLexema(lexema, fila, columna, "numero");
                            estadoActual = 0;
                            lexema = "";
                            estadoInicial--;
                            colActual--;
                        }
                        break;
                    default:
                        agregarError(lexema, fila, columna);
                        escribirEnConsola("- ERROR: No se reconoce el lexema \"" + lexema+"\" en (Fila: " + fila + ", Col: " + columna + ")");
                        estadoInicial--;
                        estadoActual = 0;
                        lexema = "";
                        break;

                }

            }
        }
        
        //*******************************************************************************************************
        string[,] token = new string[,] {
                { "ID", "Token", "Descripcion" },
                { "1", "Numero", "Secuencia de numeros" },
                { "2", "id", "Cadena de numeros y letras" },
                { "3", "cadena", "Secuencia de caracteres" },
                { "4", "tipo", "Palabra reservada" },
                { "5", "cadena", "Palabra reservada" },
                { "6", "entero", "Palabra reservada" },
                { "7", "decimal", "Palabra reservada" },
                { "8", "valor", "Palabra reservada" },
                { "9", "Inicio", "Palabra reservada" },
                { "10", "Math", "Palabra reservada" },
                { "11", "Fin", "Palabra reservada" },
                { "12", "Declaracion", "Palabra reservada" },
                { "13", "Constantes", "Palabra reservada" },
                { "14", "y", "Palabra reservada" },
                { "15", "Variables", "Palabra reservada" },
                { "16", "Funciones", "Palabra reservada" },
                { "17", "Generacion", "Palabra reservada" },
                { "18", "constante", "Palabra reservada"},
                { "19", ";", "Final de comando"},
                { "20", "(", "Parentesis abierto"},
                { "21", ")", "Parentesis cerrado"},
                { "22", ",", "Coma"},
                { "23", "=", "Signo igual, asignacion"},
                { "24", "comentarioLineal", "Secuencia de caracteres y simbolos"},
                { "25", "graficas", "Palabra reservada"},
                { "26", "Suma", "Palabra reservada, funcion de operacion"},
                { "27", "Resta", "Palabra reservada, funcion de operacion"},
                { "28", "Multiplicacion", "Palabra reservada, funcion de operacion"},
                { "29", "Division", "Palabra reservada, funcion de operacion"},
                { "30", "Potencia", "Palabra reservada, funcion de operacion"},
                { "31", "RaizCuadrada", "Palabra reservada, funcion de operacion"},
                { "32", "Seno", "Palabra reservada, funcion de operacion"},
                { "33", "Coseno", "Palabra reservada, funcion de operacion"},
                { "34", "Tangente", "Palabra reservada, funcion de operacion"},
                { "35", "Funcion", "Palabra reservada"},
                { "36", "grafica", "Palabra reservada"},
                { "37", "x_positivo", "Palabra reservada"},
                { "38", "x_negativo", "Palabra reservada"},
                { "39", "y_positivo", "Palabra reservada"},
                { "40", "y_negativo", "Palabra reservada"},
                { "41", "ancho", "Palabra reservada"},
                { "42", "largo", "Palabra reservada"},
                { "43", "ruta", "Palabra reservada"},
                { "44", "funcion", "Palabra reservada"},
                { "45", "//", "Palabra reservada"},
                { "46", "\n", "Salto de linea"},
                { "47", "grafica", "Palabra reservada"},
                { "48", "nombre", "Palabra reservada"},
                { "49", "variable", "Palabra reservada"},
                { "50", "comentarioMultilinea", "Secuencia de numeros, caracteres y simbolos en varios renglones"},
                
            };

        string[,] palabrasReservadas = new string[,] {
                { "4", "tipo" }, 
                { "5", "cadena" }, { "5", "Cadena" }, 
                { "6", "entero" },  { "6", "Entero" },
                { "7", "decimal" }, { "7", "Decimal" },
                { "8", "valor" }, { "8", "Valor" }, 
                { "9", "Inicio" }, { "9", "inicio" }, 
                { "10", "Math" }, { "10", "math" },
                { "11", "Fin" }, { "11", "fin" },
                { "12", "Declaracion" }, { "12", "declaracion" },
                { "13", "Constantes" }, { "13", "constantes" }, 
                { "14", "y" }, { "14", "Y" },
                { "15", "Variables" }, { "15", "variables" },
                { "16", "Funciones" }, { "17", "funciones" },
                { "17", "Generacion" }, { "16", "generacion" },
                { "18", "constante"}, { "18", "Constante"},
                { "19", ";"},
                { "20", "("}, 
                { "21", ")"},
                { "22", ","},
                { "23", "="},
                { "24", ""}, { "24", ""},
                { "25", "graficas"}, { "25", "Graficas"},
                { "26", "Suma"}, { "26", "suma"},
                { "27", "Resta"}, { "27", "resta"},
                { "28", "Multiplicar"}, { "28", "multiplicar"},
                { "29", "Dividir"}, { "29", "dividir"},
                { "30", "Potencia"}, { "30", "potencia"},
                { "31", "RaizCuadrada"}, { "31", "raizcuadrada"},
                { "32", "Seno"}, { "32", "seno"},
                { "33", "Coseno"}, { "33", "coseno"},
                { "34", "Tangente"}, { "34", "tangente"},
                { "35", "Funcion"}, { "35", "funcion"},
                { "36", "grafica"}, { "36", "Grafica"},
                { "37", "x_positivo"}, { "37", "X_POSITIVO"},
                { "38", "x_negativo"}, { "38", "X_NEGATIVO"},
                { "39", "y_positivo"}, { "39", "Y_POSITIVO"},
                { "40", "y_negativo"}, { "40", "Y_NEGATIVO"},
                { "41", "ancho"}, { "41", "Ancho"},
                { "42", "largo"}, { "42", "Largo"},
                { "43", "ruta"}, { "43", "Ruta"},
                { "44", "funcion"}, { "44", "Funcion"},
                { "45", "//"}, 
                { "46", "\n"}, { "46", "\n"},
                { "47", "grafica"}, { "47", "Grafica"},
                { "48", "nombre"}, { "48", "Nombre"},
                { "49", "variable"}, { "49", "Variable"}
            };

        


        List<variable> tablaVariables = new List<variable>();
        List<variable> tablaConstantes = new List<variable>();
        List<lexema> tablaDeSimbolos = new List<lexema>();
        List<error> tablaDeErrores = new List<error>();
        int num = 1;
        int numError = 1;

        private void agregarLexema(string idToken, string lexema, int fila, int columna, string token)
        {
            tablaDeSimbolos.Add(new lexema() { id = num, idToken = idToken, nombre = lexema, fila = fila, columna = columna, token = token});
            num++;
        }
        private void agregarError(string caracter, int fila, int columna)
        {
            tablaDeErrores.Add(new error() { id = numError, caracter = caracter, fila = fila, columna = columna });
            numError++;
        }

        private void agregarVariable(string nombre, string valor, string tipo)
        {
            variable var = tablaVariables.Find(x => x.nombre.Contains(nombre));
            variable cons = tablaConstantes.Find(x => x.nombre.Contains(nombre));

            if (var==null && cons == null)
            {
                tablaVariables.Add(new variable() { id = num, nombre = nombre, valor = valor, tipo = tipo  });
                escribirEnConsola("Variable: {id: " + nomVarC + ", tipo: " + tipoVarC + ", valor: " + valVarC + "}");
            }
            else
            {
                escribirEnConsola("El id de la variable ya ha sido utilizado...");
            }
           
            num++;
           
        }

        private string obtenerVariable(string nombre)
        {

            variable var = tablaVariables.Find(x => x.nombre.Contains(nombre));
            if(var == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(var.valor);
            }

        }


        private void agregarConstante(string nombre, string valor, string tipo)
        {
            variable var = tablaVariables.Find(x => x.nombre.Contains(nombre));
            variable cons = tablaConstantes.Find(x => x.nombre.Contains(nombre));

            if (var == null && cons == null)
            {
                tablaConstantes.Add(new variable() { id = num, nombre = nombre, valor = valor, tipo = tipo });
                escribirEnConsola("Constante: {id: " + nomVarC + ", tipo: " + tipoVarC + ", valor: " + valVarC + "}");
            }
            else
            {
                escribirEnConsola("El id de la constante ya ha sido utilizado...");
            }

            num++;
            num++;

        }
        
        private string obtenerConstante(string nombre)
        {

            variable var = tablaConstantes.Find(x => x.nombre.Contains(nombre));
            if (var == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(var.valor);
            }

        }
        //******************************************************************************************************

        private string validarLexema(string lexema, int fila, int columna, string tipo)
        {
            
            

            // tokens y palabras reservadas

           
            if (tipo == "numero")   //  Si viene un numero:
            {
                lexema = lexema.Replace(" ", "");
                agregarLexema(token[1, 0], lexema, fila, columna, token[1, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[1,0] + "\tToken: " + token[1,2];
                
            }
            else if(tipo == "reservado")   //   Si vienen ID o simbolos:
            {
                lexema = lexema.Replace(" ", "");
                for (int i = 0; i < palabrasReservadas.GetLength(0); i++)
                {
                    if (lexema == palabrasReservadas[i,1])
                    {
                        int id = Int32.Parse(palabrasReservadas[i, 0]);
                        agregarLexema(token[id, 0], lexema, fila, columna, token[id, 2]);
                        return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[id, 0] + "\tToken: " + token[id, 2];

                    }
                }
                agregarLexema(token[2, 0], lexema, fila, columna, token[2, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2] ;

            }
            else if (tipo == "comentarioLineal")   //  Si viene una cadena:
            {
                agregarLexema(token[24, 0], lexema, fila, columna, token[24, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2];

            }
            else if (tipo == "comentarioMultilinea")   //  Si viene una cadena:
            {
                agregarLexema(token[50, 0], lexema, fila, columna, token[50, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2];

            }
            else if (tipo == "cadena")   //  Si viene una cadena:
            {
                agregarLexema(token[3, 0], lexema, fila, columna, token[3, 2]);
                return "+ TOKEN: " + lexema + "\t(Fila: " + fila + ", Col: " + columna + ")" + "\tId Token: " + token[2, 0] + "\tToken: " + token[2, 2];

            }
            return "ERROR INESPERADO...";
        }




        // **************************    ANALIZADOR SINTACTICO   ***********************



        int numLexema = 0;
        string nomVarC = "";
        string tipoVarC = "";
        string valVarC = "";

        private lexema obtenerlexema(int idLexema)
        {
            continuar();
            try
            {
                lexema lexema = tablaDeSimbolos.Find(x => x.id.Equals(idLexema));
                return lexema;
            }
            catch { return null; }

        }

        public string error(int idLexema)
        {
            continuar();
            try
            {
                lexema lexema = tablaDeSimbolos.Find(x => x.id.Equals(idLexema));
                numLexema++;
                return " Error en: [ Fila: " + lexema.fila + " - Columna: " + lexema.columna + " ]";
            }
            catch { return null; }
        }

        private void continuar()
        {
            
            try
            {
                if (tablaDeSimbolos[numLexema].idToken == token[24, 0] || tablaDeSimbolos[numLexema].idToken == token[50, 0])
                {
                    numLexema++;
                    continuar();
                }
            }
            catch { }
            
        }

        private Boolean validar(int idToken)
        {
            continuar();
            try
            {
                if (tablaDeSimbolos[numLexema].idToken == token[idToken, 0])
                {
                    numLexema++;
                    continuar();
                    return true;
                }
                else
                {
                    numLexema++;
                    return false;
                }
               
            }
            catch { return false; }
        }

        // SE INICIA EL ANALIZADO LEXICO
        private void analizarSintaxis(string cadena)
        {
            numLexema = 0;
            graficador();
        }

        //  GRAFICADOR
        private void graficador()
        {
            if (validar(9))
            {
                if (validar(10))
                {
                    variablesYConstantes();
                    //variablesYConstantes()
                    //variablesYConstantes()
                    if (validar(11))
                    {
                        if (validar(10))
                        {
                            escribirEnConsola("SINTAXIS CORRECTA...");
                        }
                        else
                        {
                            escribirEnConsola("Se esperaba 'Math'" + error(numLexema));
                        }

                    }
                    else
                    {
                        escribirEnConsola("Se esperaba 'Fin Math'" + error(numLexema));
                    }
                }
                else
                {
                    escribirEnConsola("Se esperaba 'Math'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba 'Inicio Math'" + error(numLexema));
            }
        }

        public void variablesYConstantes()
        {
            if (validar(9))
            {
                if (validar(12))
                {
                    if (validar(13))
                    {
                        if (validar(14))
                        {
                            if (validar(15))
                            {
                                cuerpoConstantesYVariables();
                                if (validar(11))
                                {
                                    if (validar(12))
                                    {
                                        if (validar(13))
                                        {
                                            if (validar(14))
                                            {
                                                if (validar(15))
                                                {

                                                }
                                                else
                                                {
                                                    escribirEnConsola("Se esperaba 'Variables'" + error(numLexema));
                                                }
                                            }
                                            else
                                            {
                                                escribirEnConsola("Se esperaba 'y Variables'" + error(numLexema));
                                            }

                                        }
                                        else
                                        {
                                            escribirEnConsola("Se esperaba 'Constantes y Variables'" + error(numLexema));
                                        }
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba 'Declaracion Constantes y Variables'" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba 'Fin Declaracion Constantes y Variables'" + error(numLexema));
                                }
                            }
                            else
                            {
                                escribirEnConsola("Se esperaba 'Variables'" + error(numLexema));
                            }
                        }
                        else
                        {
                            escribirEnConsola("Se esperaba 'y Variables'" + error(numLexema));
                        }

                    }
                    else
                    {
                        escribirEnConsola("Se esperaba 'Constantes y Variables'" + error(numLexema));
                    }
                }
                else
                {
                    escribirEnConsola("Se esperaba 'Declaracion Constantes y Variables'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba 'Inicio Declaracion Constantes y Variables'" + error(numLexema));
            }
        }


        public void cuerpoConstantesYVariables()
        {
            if (validar(9))
            {
                nomVarC = "";
                valVarC = "";
                tipoVarC = "";

                switch (obtenerlexema(numLexema + 1).idToken)
                {
                    case "18":
                        constante();
                        break;
                    case "49":
                        variable();
                        break;
                    default:
                        escribirEnConsola("Se esperaba 'Constante' o 'Variable'" + error(numLexema));
                        break;
                }
                cuerpoConstantesYVariables();
            }
            else
            {
                numLexema--;
            }
        }
        
        public void constante()
        {
            if (validar(18))
            {
                atributos();

                if (validar(18))
                {
                    if(valVarC != "")
                    {
                        agregarConstante(nomVarC, valVarC, tipoVarC);
                    }
                    else
                    {
                        escribirEnConsola("Una o mas variables o constantes no han sido declaradas..." + nomVarC);
                    }
                    
                }
                else
                {
                    escribirEnConsola("Se esperaba 'Constante'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba 'constante'" + error(numLexema));
            }
        }

        public void variable()
        {
            if (validar(49))
            {
                atributos();

                if (validar(49))
                {
                    if (valVarC != "")
                    {
                        agregarVariable(nomVarC, valVarC, tipoVarC);
                        
                    }
                    else
                    {
                        escribirEnConsola("Una o mas variables o constantes no han sido declaradas..." + nomVarC);
                    }
                }
                else
                {
                    escribirEnConsola("Se esperaba 'Variable'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba 'Variable'" + error(numLexema));
            }
        }

        public void atributos()
        {
            switch (obtenerlexema(numLexema + 1).idToken)
            {
                case "48":
                    nombre();
                    if (validar(22))
                    {
                        switch (obtenerlexema(numLexema + 1).idToken)
                        {
                            case "4":
                                tipo();
                                if (validar(22))
                                {
                                    valor();
                                    if (validar(11))
                                    {
                                        // se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                            case "8":
                                valor();
                                if (validar(22))
                                {
                                    tipo();
                                    if (validar(11))
                                    {
                                        /// se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                        }
                        
                    }
                    else
                    {
                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                    }
                    break;
                case "8":
                    valor();
                    if (validar(22))
                    {
                        switch (obtenerlexema(numLexema + 1).idToken)
                        {
                            case "48":
                                nombre();
                                if (validar(22))
                                {
                                    tipo();
                                    if (validar(11))
                                    {
                                        /// se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                            case "4":
                                tipo();
                                if (validar(22))
                                {
                                    nombre();
                                    if (validar(11))
                                    {
                                        /// se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                        }

                    }
                    else
                    {
                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                    }
                    break;
                case "4":
                    tipo();
                    if (validar(22))
                    {
                        switch (obtenerlexema(numLexema + 1).idToken)
                        {
                            case "8":
                                valor();
                                if (validar(22))
                                {
                                    nombre();
                                    if (validar(11))
                                    {
                                        /// se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                            case "48":
                                nombre();
                                if (validar(22))
                                {
                                    valor();
                                    if (validar(11))
                                    {
                                        /// se acepta
                                    }
                                    else
                                    {
                                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                                    }
                                }
                                else
                                {
                                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                                }
                                break;
                        }

                    }
                    else
                    {
                        escribirEnConsola("Se esperaba ','" + error(numLexema));
                    }
                    break;
            }
            
        }



        public void nombre()
        {
            if (validar(48))
            {
                if (validar(23))
                {
                    if (validar(2))
                    {
                        nomVarC = obtenerlexema(numLexema).nombre;
                    }
                    else
                    {
                        escribirEnConsola("Se esperaba secuencia de caracteres" + error(numLexema));
                    }
                }
                else
                {
                    escribirEnConsola("Se esperaba '='" + error(numLexema));
                }

            }
            else
            {
                escribirEnConsola("Se esperaba un 'nombre'" + error(numLexema));
            }
        }
        public void valor()
        {
            if (validar(8))
            {
                if (validar(23))
                {
                    switch (obtenerlexema(numLexema + 1).idToken)
                    {
                        case "1":
                            valVarC = obtenerlexema(numLexema + 1).nombre;
                            numLexema++;
                            break;
                        case "2":
                            valVarC = obtenerConstante(obtenerlexema(numLexema + 1).nombre);
                            valVarC = obtenerVariable(obtenerlexema(numLexema + 1).nombre);
                            numLexema++;
                            break;
                        case "3":
                            valVarC = obtenerlexema(numLexema + 1).nombre;
                            numLexema++;
                            break;
                        default:
                            valVarC = operacion();
                            break;
                    }
                }
                else
                {
                    escribirEnConsola("Se esperaba '=' " + error(numLexema));
                }

            }
            else
            {
                escribirEnConsola("Se esperaba un 'valor'" + error(numLexema));
            }
        }
        public void tipo()
        {
            if (validar(4))
            {
                if (validar(23))
                {
                    switch (obtenerlexema(numLexema+1).idToken)
                    {
                        case "5":
                            tipoVarC = obtenerlexema(numLexema + 1).nombre;
                            numLexema++;
                            break;
                        case "6":
                            tipoVarC = obtenerlexema(numLexema + 1).nombre;
                            numLexema++;
                            break;
                        case "7":
                            tipoVarC = obtenerlexema(numLexema + 1).nombre;
                            numLexema++;
                            break;
                        default:
                            escribirEnConsola("Se esperaba 'cadena', 'entero' o 'decimal'" + error(numLexema));
                            break;
                    }
                    
                }
                else
                {
                    escribirEnConsola("Se esperaba '='" + error(numLexema));
                }

            }
            else
            {
                escribirEnConsola("Se esperaba 'tipo'" + error(numLexema));
            }
        }

        public string operacion()
        {
            string valor = "";
            switch (obtenerlexema(numLexema + 1).idToken)
            {
                case "26":
                    valor = suma();
                    break;
                case "27":
                    valor = resta();
                    break;
                case "28":
                    valor = multiplicacion();
                    break;
                case "29":
                    valor = division();
                    break;
                case "30":
                    valor = potencia();
                    break;
                case "31":
                    valor = raizCuadrada();
                    break;
                case "32":
                    valor = seno();
                    break;
                case "33":
                    valor = coseno();
                    break;
                case "34":
                    valor = tangente();
                    break;
                default:
                    escribirEnConsola("Se esperaba numero, Id, cadena de caracteres o una operacion" + error(numLexema));
                    break;
            }
            return valor;
        }

        public string suma()
        {
            double total = 0;
            if (validar(26))
            {
                string[,] valor = operacionBinaria();
                total = Convert.ToDouble(valor[0, 0]) + Convert.ToDouble(valor[0, 1]);
            }
            else
            {
                escribirEnConsola("Se esperaba 'Suma'" + error(numLexema));
            }
            return "" + total;
        }
        public string resta()
        {
            double total = 0;
            if (validar(27))
            {
                string[,] valor = operacionBinaria();
                total = Convert.ToDouble(valor[0, 0]) - Convert.ToDouble(valor[0, 1]);
            }
            else
            {
                escribirEnConsola("Se esperaba 'Resta'" + error(numLexema));
            }
            return "" + total;
        }

        public string multiplicacion()
        {
            double total = 0;
            if (validar(28))
            {
                string[,] valor = operacionBinaria();
                total = Convert.ToDouble(valor[0, 0]) * Convert.ToDouble(valor[0, 1]);
            }
            else
            {
                escribirEnConsola("Se esperaba 'Multiplicar'" + error(numLexema));
            }
            return "" + total;
        }

        public string division()
        {
            double total = 0;
            if (validar(29))
            {
                string[,] valor = operacionBinaria();
                total = Convert.ToDouble(valor[0, 0]) / Convert.ToDouble(valor[0, 1]);
            }
            else
            {
                escribirEnConsola("Se esperaba 'Dividir'" + error(numLexema));
            }
            return "" + total;
        }

        public string potencia()
        {
            double total = 0;
            if (validar(30))
            {
                string[,] valor = operacionBinaria();
                total = System.Math.Pow(Convert.ToDouble(valor[0, 0]),  Convert.ToDouble(valor[0, 1]));
            }
            else
            {
                escribirEnConsola("Se esperaba 'Potencia'" + error(numLexema));
            }
            return "" + total;
        }

        public string raizCuadrada()
        {
            double total = 0;
            if (validar(31))
            {
                string valor = operacionUnaria();
                total = System.Math.Sqrt(Convert.ToDouble(valor));
            }
            else
            {
                escribirEnConsola("Se esperaba 'RaizCuadrada'" + error(numLexema));
            }
            return "" + total;
        }

        public string seno()
        {
            double total = 0;
            if (validar(32))
            {
                string valor = operacionUnaria();
                total = System.Math.Sin(Convert.ToDouble(valor));
            }
            else
            {
                escribirEnConsola("Se esperaba 'Seno'" + error(numLexema));
            }
            return "" + total;
        }

        public string coseno()
        {
            double total = 0;
            if (validar(33))
            {
                string valor = operacionUnaria();
                total = System.Math.Cos(Convert.ToDouble(valor));
            }
            else
            {
                escribirEnConsola("Se esperaba 'Coseno'" + error(numLexema));
            }
            return "" + total;
        }

        public string tangente()
        {
            double total = 0;
            if (validar(34))
            {
                string valor = operacionUnaria();
                total = System.Math.Tan(Convert.ToDouble(valor));
            }
            else
            {
                escribirEnConsola("Se esperaba 'Tangente'" + error(numLexema));
            }
            return "" + total;
        }

        public string [,] operacionBinaria()
        {
            string[,] valores = new string[,] { { "", "" }, } ;
            if (validar(20))
            {
                switch (obtenerlexema(numLexema + 1).idToken)
                {
                    case "1":
                        valores[0, 0] = obtenerlexema(numLexema + 1).nombre;
                        numLexema++;
                        break;
                    case "2":
                        valores[0, 0] = obtenerVariable(obtenerlexema(numLexema + 1).nombre);
                        if (valores[0, 0] == "")
                            valores[0, 0] = obtenerConstante(obtenerlexema(numLexema + 1).nombre);
                        numLexema++;
                        break;
                    default:
                        valores[0, 0] = operacion();
                        break;
                }

                if (!validar(22))
                {
                    escribirEnConsola("Se esperaba ','" + error(numLexema));
                }

                switch (obtenerlexema(numLexema + 1).idToken)
                {
                    case "1":
                        valores[0, 1] = obtenerlexema(numLexema + 1).nombre;
                        numLexema++;
                        break;
                    case "2":
                        valores[0, 1] = obtenerVariable(obtenerlexema(numLexema + 1).nombre);
                        if(valores[0, 1]=="")
                        valores[0, 1] = obtenerConstante(obtenerlexema(numLexema + 1).nombre);
                        numLexema++;
                        break;
                    default:
                        valores[0, 1] = operacion();
                        break;
                }
                if (!validar(21))
                {
                    escribirEnConsola("Se esperaba ')'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba '('" + error(numLexema));
            }
            if (valores[0, 0] == "")
            {
                valores[0, 0] = "0";
            }
            if (valores[0, 1] == "")
            {
                valores[0, 1] = "0";
            }
            return valores;
        }

        public string operacionUnaria()
        {
            string valor = "";
            if (validar(20))
            {
                switch (obtenerlexema(numLexema + 1).idToken)
                {
                    case "1":
                        valor = obtenerlexema(numLexema + 1).nombre;
                        numLexema++;
                        break;
                    case "2":
                        valor = obtenerlexema(numLexema + 1).nombre;
                        numLexema++;
                        break;
                    default:
                        valor = operacion();
                        break;
                }
                if (!validar(21))
                {
                    escribirEnConsola("Se esperaba ')'" + error(numLexema));
                }
            }
            else
            {
                escribirEnConsola("Se esperaba '('" + error(numLexema));
            }
            return valor;
        }

        // **************************    FUNCIONES   ***********************

            //  tamañolienzo

        private void tamaniolienzo(int x, int y)
        {
            lienzo.Width = a*x;
            lienzo.Height = a*y;
            tortuga.SetBounds(lienzo.Width/2-16, lienzo.Height/2-16, 32,32);
        }

        //  colorlienzo
        private void colorlienzo(string color)
        {
            color = color.ToLower();
            Console.WriteLine(color);
            switch (color)
            {
                case "celeste":
                    lienzo.BackColor = Color.LightBlue;
                    break;
                case "amarillo":
                    lienzo.BackColor = Color.Yellow;
                    break;
                case "blanco":
                    lienzo.BackColor = Color.White;
                    break;
                default:
                    escribirEnConsola("Color no reconocido...");
                    break;
            }
             
        }

        //  avanzar:

        private void obtenerXY()
        {
            xActual = tortuga.Bounds.X + 16;
            yActual = tortuga.Bounds.Y + 16;
        }

        private void avanzar(double c)
        {
            c = c * a;
            double angulo = anguloActual;

            double xDouble = c * Math.Cos(angulo);
            double yDouble = c * Math.Sin(angulo);

            double x = Math.Round(xDouble);
            double y = Math.Round(yDouble);

            if (pincelAbajo) {
                pintar(x, y, c);
            }
            
            
            if (xActual + x > lienzo.Size.Width)
            {
                xActual = lienzo.Size.Width;
            }
            else if(xActual + x < 0)
            {
                xActual = 0;
            }
            else
            {
                xActual = xActual + x;
            }

            if (yActual - y > lienzo.Size.Height)
            {
                yActual = lienzo.Size.Height;
            }
            else if (yActual - y < 0)
            {
                yActual = 0;
            }
            else
            {
                yActual = yActual - y;
            }

            ir(xActual, yActual);
            
        }

        // girarIzq:

        private void girarIzq(double angulo)
        {
            anguloActual = anguloActual + angulo * Math.PI / 180.0;
            //tortuga.Image = rotateImage(tortuga, anguloActual);
        }

        // girarDer:

        private void girarDer(double angulo)
        {
            anguloActual = anguloActual - angulo * Math.PI / 180.0;
        }

        // ir:
        
        private void ir(double x, double y)
        {
            xActual = x;
            yActual = y;

            //dejar caquita
            Label label1 = new Label();
            label1.SetBounds((int)xActual-2, (int)yActual-2, 5, 5);
            lienzo.Controls.Add(label1);
            label1.BackColor = Color.Black;

            tortuga.SetBounds((int)xActual-16, (int)yActual-16, 32, 32);
            Console.WriteLine("Ubicacion: "+xActual+", "+yActual);

        }

        //   FUNCION AUXILIAR:

        private void agregarPixel(int m, int n)
        {

            Label label1 = new Label();
            label1.SetBounds(m, n, 2, 2);
            lienzo.Controls.Add(label1);

            switch (colorPixel)
            {
                case "azul":
                    label1.BackColor = Color.Blue;
                    break;
                case "rojo":
                    label1.BackColor = Color.Red;
                    break;
                case "negro":
                    label1.BackColor = Color.Black;
                    break;
                default:
                    escribirEnConsola("Color no reconocido...");
                    break;
            }
        }

        // retroceder

        private void retroceder(int c)
        {
            anguloActual += Math.PI;
            avanzar(c);
            anguloActual += Math.PI;
        }

        // colorpincel
        
        private void colorPincel(string color)
        {
            colorPixel = color;
        }
        
        //   FUNCION PINTAR:

        private void pintar(double x, double y, double c)
        {
            if (y == 0)
            {
                y = 1;
            }
            else if(x == 0)
            {
                x = 1;
            }

            Console.WriteLine("Ubicacion PINTAR: " + xActual + ", " + yActual);
            Console.WriteLine("x: " + x + ", y: " + y);
            double salto = 0;
            int m = (int)xActual, n = (int)yActual;
            if (Math.Cos(anguloActual) >= 0 && Math.Tan(anguloActual) >= 0)
            {
                marcador(salto, m, n, x, y, true, true);
            }
            else if (Math.Cos(anguloActual) <= 0 && Math.Tan(anguloActual) <= 0)
            {
                marcador(salto, m, n, x, y, false, true);
            }
            else if (Math.Cos(anguloActual) <= 0 && Math.Tan(anguloActual) >= 0)
            {
                marcador(salto, m, n, x, y, false, false);
            }
            else if (Math.Cos(anguloActual) >= 0 && Math.Tan(anguloActual) <= 0)
            {
                marcador(salto, m, n, x, y, true, false);
            }


        }

        // PINTAR
        private void marcador(double salto, int m, int n, double x, double y, Boolean mBoolean, Boolean nBoolean)
        {
            double total = 0;
            Boolean xMayor = true;
            x = Math.Abs(x);
            y = Math.Abs(y);
            if (y > x)
            {
                salto = y / x;
                xMayor = false;
                total = x;
            }
            else if (y < x)
            {
                salto = x / y;
                xMayor = true;
                total = y;
            }
            else
            {
                for (int i = 0; i < x; i++)
                { 
                    agregarPixel(m, n);
                    if (mBoolean && nBoolean && xMayor) { m++; n--; }
                    else if (!mBoolean && nBoolean && xMayor) { m--; n--; }
                    else if (!mBoolean && !nBoolean && xMayor) { m--; n++; }
                    else if (mBoolean && !nBoolean && xMayor) { m++; n++; }
                }
            }

            int saltoInt = (int)salto;
            double deci = salto - saltoInt;
            double deci2 = 0;

            for (int j = 0; j < total; j++)
            {
                deci2 = deci2 + deci;
                for (int i = 0; i < saltoInt; i++)
                {
                    agregarPixel(m, n);

                    if (mBoolean && nBoolean && !xMayor) { n--; }
                    else if (mBoolean && nBoolean && xMayor) { m++; }

                    else if (!mBoolean && nBoolean && !xMayor) { n--; }
                    else if (!mBoolean && nBoolean && xMayor) { m--; }

                    else if (!mBoolean && !nBoolean && !xMayor) { n++; }
                    else if (!mBoolean && !nBoolean && xMayor) { m--; }

                    else if (mBoolean && !nBoolean && !xMayor) { n++; }
                    else if (mBoolean && !nBoolean && xMayor) { m++; }

                    if (deci2 >= 1.0)
                    {
                        deci2 = deci2 - 1.0;
                        agregarPixel(m, n);

                        if (mBoolean && nBoolean && !xMayor) { n--; }
                        else if (mBoolean && nBoolean && xMayor) { m++; }

                        else if (!mBoolean && nBoolean && !xMayor) { n--; }
                        else if (!mBoolean && nBoolean && xMayor) { m--; }

                        else if (!mBoolean && !nBoolean && !xMayor) { n++; }
                        else if (!mBoolean && !nBoolean && xMayor) { m--; }

                        else if (mBoolean && !nBoolean && !xMayor) { n++; }
                        else if (mBoolean && !nBoolean && xMayor) { m++; }
                    }

                    if (Math.Round(deci2) == 1 && j < x)
                    {
                        if (mBoolean && nBoolean && !xMayor) { agregarPixel(m + 1, n); }
                        else if (mBoolean && nBoolean && xMayor) { agregarPixel(m, n-1); }

                        else if (!mBoolean && nBoolean && !xMayor) { agregarPixel(m-1, n ); }
                        else if (!mBoolean && nBoolean && xMayor) { agregarPixel(m, n - 1); }

                        else if (!mBoolean && !nBoolean && !xMayor) { agregarPixel(m - 1, n); }
                        else if (!mBoolean && !nBoolean && xMayor) { agregarPixel(m, n + 1); }

                        else if (mBoolean && !nBoolean && !xMayor) { agregarPixel(m + 1, n); }
                        else if (mBoolean && !nBoolean && xMayor) { agregarPixel(m , n + 1); }
                    }
                }

                if (mBoolean && nBoolean && xMayor) { n--; }
                else if (mBoolean && nBoolean && !xMayor) { m++; ; }

                else if (!mBoolean && nBoolean && xMayor) { n--; }
                else if (!mBoolean && nBoolean && !xMayor) { m--; }

                else if (!mBoolean && !nBoolean && xMayor) { n++; }
                else if (!mBoolean && !nBoolean && !xMayor) { m--; }

                else if (mBoolean && !nBoolean && xMayor) { n++; }
                else if (mBoolean && !nBoolean && !xMayor) { m++; }
            }
        }

        //  centrar

        private void centrar()
        {
            int x = lienzo.Width/2;
            int y = lienzo.Height/2;
            ir(x, y);
        }

        // irX

        private void irX(int x)
        {
            ir(x , yActual);
        }

        // irY

        private void irY(int y)
        {
            ir(xActual, y);
        }

        // subirPincel/bajarPincel

        private void subirPincel()
        {
            pincelAbajo = false;
        }
        private void bajarPincel()
        {
            pincelAbajo = true;
        }

        // VARIABLES

        double xActual = 0;
        double yActual = 0;
        string colorPixel = "azul";
        Boolean pincelAbajo = true;
        double anguloActual = Math.PI / 2;
        int a = 5;
        
        public int evaluarExpresion(string expresion)
        {
            Evaluador1 evaluador = new Evaluador1();
            evaluador.evaluarExpresion(expresion);
            double r = evaluador.F();
            int resultadoInt = (int)Math.Round(r);
            //escribirEnConsola("Evaluando: " + expresion);
            return resultadoInt;
        }
        

        //  Ejecutor

        private void ejecutar()
        {
            escribirEnConsola("Ejecutando instrucciones...");
            agregarLexema("error", "error", 0, 0,"error");
            agregarLexema("error1", "error1", 0, 0,"error");

            int estadoInicial = 0;
            int estadoActual = 0;
            string tokenactual;
            string tokenVariable = "";
            string tokenAuxiliar = "";
            string expresion = "";
            string comando = " ";
            string tId = "";
            string x = "", y = "";


            for (estadoInicial = 0; estadoInicial < tablaDeSimbolos.Count; estadoInicial++)
            {
                tokenactual = tablaDeSimbolos[estadoInicial].nombre;
                tId = tablaDeSimbolos[estadoInicial].idToken;

                switch (estadoActual)
                {
                    case 0:
                        if(tId == "4")
                        {
                            estadoActual = 1;
                            comando += tokenactual + " ";
                        }
                        else if (tId == "2")
                        {
                            estadoActual = 2;
                            comando += tokenactual + " ";
                            tokenVariable = tokenactual;
                        }
                        else if (tId == "3")
                        {
                            estadoActual = 8;
                            comando += tokenactual + " ";
                            
                        }
                        else if (tId == "5" || tId == "12")
                        {
                            estadoActual = 13;
                            comando += tokenactual + " ";
                            tokenAuxiliar = tId;
                        }
                        else if (tId == "7" || tId == "8" || tId == "9" || tId == "10" || tId == "13" || tId == "14")
                        {
                            estadoActual = 18;
                            comando += tokenactual + " ";
                            tokenAuxiliar = tId;
                        }
                        else if (tId == "6" || tId == "17")
                        {
                            estadoActual = 21;
                            comando += tokenactual + " ";
                            tokenAuxiliar = tId;
                        }
                        else if (tId == "15" || tId == "16" || tId == "11")
                        {
                            estadoActual = 24;
                            comando += tokenactual + " ";
                            tokenAuxiliar = tId;
                        }
                        else {estadoActual = 500;}

                        break;
                    case 1:
                        if (tId == "2")
                        {
                            estadoActual = 2;
                            comando += tokenactual + " ";
                            tokenVariable = tokenactual;

                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 2:
                        if (tId == "23")
                        {
                            estadoActual = 3;
                            comando += tokenactual + " ";
                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 3: // caso numero o variable
                        if (tId == "1")
                        {
                            estadoActual = 4;
                            comando += tokenactual + " ";
                            expresion += tokenactual + " ";

                        }
                        else if (tId == "2")
                        {
                            estadoActual = 4;
                            comando += tokenactual + " ";
                            expresion += obtenerVariable(tokenactual) + " ";
                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 4:
                        if (tId == "18")
                        {
                            estadoActual = 5;
                            comando += tokenactual + " ";
                            expresion += tokenactual + " ";
                        }
                        else if (tId == "19")
                        {
                            estadoActual = 7;
                            comando += tokenactual + " ";
                            estadoInicial--;
                            
                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 5:
                        if (tId == "2")
                        {
                            estadoActual = 6;
                            comando += tokenactual + " ";
                            expresion += obtenerVariable(tokenactual) + " ";
                            
                        }
                        else if (tId == "1")
                        {
                            estadoActual = 4;
                            comando += tokenactual + " ";
                            expresion += tokenactual + " ";
                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 6:
                        if (tId == "18")
                        {
                            estadoActual = 5;
                            comando += tokenactual + " ";
                            expresion += tokenactual + " ";
                        }
                        else if (tId == "1")
                        {
                            estadoActual = 4;
                            comando += tokenactual + " ";
                            expresion += tokenactual + " ";
                        }
                        else if (tId == "19")
                        {
                            
                            estadoActual = 7;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else
                        {
                            estadoActual = 500;
                        }
                        break;
                    case 7:
                        //Asignar valor
                        //escribirEnConsola("Ejecutando instruccion: " + comando);

                        if (ValidarExpresion(expresion))
                        {
                            int valorVariable = evaluarExpresion(expresion);
                            //agregarVariable(tokenVariable, valorVariable);
                        }
                        else
                        {
                            escribirEnConsola("Una o mas variables no declaradas...\r\n Se detiene la ejecucion...");
                        }


                        // LIMPIAR
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = " ";
                        comando = " ";

                        break;

                    case 8: // FUNCION ESCRIBIR
                        if(tId == "20")
                        {
                            estadoActual = 9;
                            comando += tokenactual + " ";
                        }
                        else{estadoActual = 500;}
                        break;
                    case 9: 
                        if (tId == "2")
                        {
                            estadoActual = 10;
                            comando += tokenactual + " ";
                            tokenVariable = tokenactual;
                        }else { estadoActual = 500; }
                        break;
                    case 10:
                        if (tId == "21")
                        {
                            estadoActual = 11;
                            comando += tokenactual + " ";
                           
                        }
                        else { estadoActual = 500; }
                        break;
                    case 11:
                        if (tId == "19")
                        {
                            estadoActual = 12;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 12:
                        expresion = obtenerVariable(tokenVariable);
                        if (ValidarExpresion(expresion))
                        {
                            escribirEnConsola(expresion);
                        }
                        else
                        {
                            escribirEnConsola("Una o mas variables no declaradas...\r\n Se detiene la ejecucion...");
                        }
                        

                        // LIMPIAR
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = " ";
                        comando = " ";
                        break;



                    case 13:    //  BUNCION TAMAÑOLIENZO / IRX
                        if (tId == "1")
                        {
                            estadoActual = 14;
                            comando += tokenactual + " ";
                            x = tokenactual;
                        }
                        else if(tId == "2")
                        {
                            estadoActual = 14;
                            comando += tokenactual + " ";
                            x = obtenerVariable(tokenactual) + " ";
                        }
                        else { estadoActual = 500; }
                        break;
                    case 14:
                        if (tId == "22")
                        {
                            estadoActual = 15;
                            comando += tokenactual + " ";

                        }
                        else { estadoActual = 500; }
                        break;
                    case 15:
                        if (tId == "1")
                        {
                            estadoActual = 16;
                            comando += tokenactual + " ";
                            y = tokenactual;
                        }
                        else if (tId == "2")
                        {
                            estadoActual = 16;
                            comando += tokenactual + " ";
                            y = obtenerVariable(tokenactual) + " ";
                        }
                        else { estadoActual = 500; }
                        break;
                    case 16:
                        if (tId == "19")
                        {
                            estadoActual = 17;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 17:

                        if (ValidarExpresion(x) && ValidarExpresion(y))
                        {
                            if(tokenAuxiliar == "12")
                            {
                                ir(Convert.ToInt16(x), Convert.ToInt16(y));
                            }
                            else
                            {
                                tamaniolienzo(Convert.ToInt16(x), Convert.ToInt16(y));
                            }
                            
                        }
                        else
                        {
                            escribirEnConsola("una o mas variables no declaradas...\r\n Se detiene la ejecucion...");
                        }

                        // LIMPIAR
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = " ";
                        comando = " ";
                        x = "";
                        y = "";
                        break;
                    case 18:    //  FUNCION 789101314 
                        if (tId == "1")
                        {
                            estadoActual = 19;
                            comando += tokenactual + " ";
                            x = tokenactual;
                        }
                        else if (tId == "2")
                        {
                            estadoActual = 19;
                            comando += tokenactual + " ";
                            x = obtenerVariable(tokenactual) + " ";
                        }
                        else { estadoActual = 500; }
                        break;
                    case 19:
                        if (tId == "19")
                        {
                            estadoActual = 20;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 20:

                        if (ValidarExpresion(x))
                        {
                            if (tokenAuxiliar == "7")
                            {
                                avanzar(Convert.ToInt16(x));
                            }
                            else if(tokenAuxiliar == "8")
                            {
                                retroceder(Convert.ToInt16(x));
                            }
                            else if (tokenAuxiliar == "9")
                            {
                                girarIzq(Convert.ToInt16(x));
                            }
                            else if (tokenAuxiliar == "10")
                            {
                                girarDer(Convert.ToInt16(x));
                            }
                            else if (tokenAuxiliar == "13")
                            {
                                irX(Convert.ToInt16(x));
                            }
                            else if (tokenAuxiliar == "14")
                            {
                                irY(Convert.ToInt16(x));
                            }

                        }
                        else
                        {
                            escribirEnConsola("una o mas variables no declaradas...\r\n Se detiene la ejecucion...");
                        }

                        // LIMPIAR
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = " ";
                        comando = " ";
                        x = "";
                        y = "";
                        break;
                    case 21:
                        if (tId == "2")
                        {
                            estadoActual = 22;
                            comando += tokenactual + " ";
                            expresion += tokenactual;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 22:
                        if (tId == "19")
                        {
                            estadoActual = 23;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 23:
                        expresion = expresion.Trim();
                        if (!ValidarExpresion(expresion))
                        {
                           
                            if (tokenAuxiliar == "6")
                            {
                                if (expresion == "celeste" || expresion == "amarillo" || expresion == "blanco")
                                {
                                    colorlienzo(expresion);
                                }
                                else
                                {
                                    escribirEnConsola("Color "+expresion+" no reconocido...");
                                }
                            }
                            else if(tokenAuxiliar == "17" )
                            {
                                if (expresion == "rojo" || expresion == "azul" || expresion == "negro")
                                {
                                    colorPincel(expresion);
                                }
                                else
                                {
                                    escribirEnConsola("Color " + expresion + " no reconocido...");
                                }
                                
                            }

                        }
                        else
                        {
                            escribirEnConsola("Una o mas variables no declaradas...\r\n Se detiene la ejecucion...");
                        }

                        // LIMPIAR
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = "";
                        comando = " ";
                        x = "";
                        y = "";
                        break;
                    case 24:
                        if (tId == "19")
                        {
                            estadoActual = 25;
                            comando += tokenactual + " ";
                            estadoInicial--;
                        }
                        else { estadoActual = 500; }
                        break;
                    case 25:
                        if(tokenAuxiliar == "15")
                        {
                            subirPincel();
                        }
                        else if (tokenAuxiliar == "16")
                        {
                            bajarPincel();
                        }
                        else
                        {
                            centrar();
                        }
                        estadoActual = 0;
                        tokenVariable = " ";
                        expresion = "";
                        comando = " ";
                        x = "";
                        y = "";
                        break;
                    case 500:
                        estadoInicial = 500;
                        if (!(comando == " ")) {
                            escribirEnConsola("No se reconoce la instruccion o esta incompleta...\r\n \"" + comando + "\"\r\n Se detiene la ejecucion...");
                        }
                        else
                        {
                            escribirEnConsola("Se espera una o mas instrucciones...");
                        }
                        comando = " ";
                        break;

                }
            }


            lexema eliminar = tablaDeSimbolos.Single(r => r.nombre == "error");
            tablaDeSimbolos.Remove(eliminar);
            eliminar = tablaDeSimbolos.Single(r => r.nombre == "error1");
            tablaDeSimbolos.Remove(eliminar);
        }
        public Boolean ValidarExpresion(string expresion)
        {
            List<char> Validos = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '/', '*', '^', ' ' };
            foreach(char a in expresion.ToCharArray())
            {
                
                if (Validos.IndexOf(a) == -1)
                {
                    
                    return false;
                    

                }
                
            }
            return true;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //tamaniolienzo(300, 300);
            //colorlienzo("celeste");
            //avanzar(50);
            //centrar();
            //subirPincel();
            //avanzar(50);
            //girarDer(20);
            //avanzar(50);
            //girarIzq(100);
            //bajarPincel();
            //avanzar(50);
            //Console.WriteLine("hola como estas");
            retroceder(20);
            //string pf = e.ConvertirInfija(exp);

            //ejecutar();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void escribirEnConsola(string  texto)
        {
            consola.Text += texto + "\r\n KTurtle# ";

            consola.SelectionStart = consola.Text.Length;
            consola.Focus();
            consola.ScrollToCaret();
            consola.ReadOnly = true;
        }

        private void consola_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            escribirEnConsola("Analizando los lexemas...");
           

            tablaDeSimbolos.Clear();
            tablaVariables.Clear();
            tablaConstantes.Clear();
            tablaDeErrores.Clear();
            num = 1;
            numError = 1;
            anguloActual = Math.PI / 2;

            string cadena = textoentrada1.Text + " ";
            analizarLenguaje(cadena);

            ejecutar();
        }


        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = textoentrada1.Text;
            if (rutaArchivo == null)
            {
                rutaArchivo = guardarComo(texto);
                
              
            }
            else
            {
                StreamWriter fichero = new StreamWriter(rutaArchivo);
                fichero.WriteLine(texto);
                fichero.Close();
            }
        }

        // GUARDAR COMO 

        private string agregarSaltoLinea()
        {
            string textoSalida = "";
            int lineaActual = 0;
            int inicio = 0;
            for (int i = 0; i < textoentrada1.Text.Length+1; ++i)
            {
                int linea = textoentrada1.GetLineFromCharIndex(i);
                if (linea > lineaActual)
                {
                    textoSalida += textoentrada1.Text.Substring(inicio, i - inicio) + Environment.NewLine;
                    inicio = i;
                    lineaActual = linea;
                }
            }
            textoSalida += textoentrada1.Text.Substring(inicio);
            return textoSalida;
        }
       

        string rutaArchivo = null;
        public string guardarComo(string texto)
        {
            SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar proyecto de KTortle";
            saveFileDialog1.Filter = "Archivo de KTurtle (.ktl) |*.ktl";

            saveFileDialog1.DefaultExt = "ktl";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"H:\LO DEL ESCRITORIO";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = saveFileDialog1.FileName;

                StreamWriter fichero = new StreamWriter(rutaArchivo);
                fichero.Write(texto);
                fichero.Close();
                this.Text = "KTurtle " + rutaArchivo;
                guardarToolStripMenuItem.Text = "Guardar: " + rutaArchivo;
                return rutaArchivo;
            }
            else
            {
                saveFileDialog1.Dispose();
                saveFileDialog1 = null;
                return null;
            }
            
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = textoentrada1.Text;
            rutaArchivo = guardarComo(texto);

        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Title = "Abrir proyecto de KTortle";
            oFD.Filter = "Proyecto de KTurtle (*.ktl)|*.ktl" +
            "|Todos los archivos (*.*)|*.*";
            
            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rutaArchivo = oFD.FileName;
                textoentrada1.Text = System.IO.File.ReadAllText(rutaArchivo);
                this.Text = "KTurtle "+rutaArchivo;
                guardarToolStripMenuItem.Text = "Guardar: " + rutaArchivo;
            }
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string rutaTablaDeSimbolos = " ";
        string rutaTablaDeErrores = "";

        private void generarTablaDeErrores()
        {

            string html = "<center><h1 style=\'text-align: center;\'>KTurtle</h1><h2 style=\'text-align: center;\'>Tabla de errores:</h2><hr /><p>​&nbsp;</p><table style=\'width: 800px;\' border=\'1\' cellspacing=\'1\' cellpadding=\'1\'><thead><tr><th scope=\'col\'><span style=\'color: #000000;\'>#</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Fila</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Columna</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Caracter</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Id Descripcion</span>"
            + "</tr></thead><tbody>";

            for (int i = 0; i < tablaDeErrores.Count; i++)
            {
                string lexemas = "<tr><td style=\'text-align: center;\'> "+ tablaDeErrores[i].id + "</td><td style=\'text-align: center;\'> " + tablaDeErrores[i].fila + "</td><td style=\'text-align: center;\'>" + tablaDeErrores[i].columna + "</td><td style=\'text-align: center;\'>" + tablaDeErrores[i].caracter + "</td><td>Desconocido</td></tr>";
                html += lexemas;
            }

            html +="</tbody></table><p>&nbsp;</p><hr /><p>&nbsp;</p></center>";

            SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Generar tabla de errores";
            saveFileDialog1.Filter = "Archivo de html (.html) |*.html";
           
            saveFileDialog1.DefaultExt = "html";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"H:\LO DEL ESCRITORIO";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaTablaDeErrores = saveFileDialog1.FileName;

                StreamWriter fichero = new StreamWriter(rutaTablaDeErrores);
                fichero.Write(html);
                fichero.Close();
                Process.Start(rutaTablaDeErrores);
            }
            else
            {
                saveFileDialog1.Dispose();
                saveFileDialog1 = null;
            }
            
        }

        private void generarTablaDeSimbolos()
        {

            string html = "<center><h1 style=\'text-align: center;\'>KTurtle</h1><h2 style=\'text-align: center;\'>Tabla de simbolos:</h2><hr /><p>​&nbsp;</p><table style=\'width: 800px;\' border=\'1\' cellspacing=\'1\' cellpadding=\'1\'><thead><tr><th scope=\'col\'><span style=\'color: #000000;\'>#</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Lexema</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Fila</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Columna</span></th>"
            + "<th scope=\'col\'><span style=\'color: #000000;\'>Id Token</span></th><th scope=\'col\'><span style=\'color: #000000;\'>Token</span></th>"
            + "</tr></thead><tbody>";

            for (int i = 0; i < tablaDeSimbolos.Count; i++)
            {
                string lexemas = "<tr><td style=\'text-align: center;\'> " + tablaDeSimbolos[i].id + "</td><td style=\'text-align: center;\'> " + tablaDeSimbolos[i].nombre + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].fila + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].columna + "</td><td style=\'text-align: center;\'>" + tablaDeSimbolos[i].idToken + "</td><td>" + tablaDeSimbolos[i].token + "</td></tr>";
                html += lexemas;
            }

            html += "</tbody></table><p>&nbsp;</p><hr /><p>&nbsp;</p></center>";

            SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Generar tabla de simbolos";
            saveFileDialog1.Filter = "Archivo de html (.html) |*.html";

            saveFileDialog1.DefaultExt = "html";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"H:\LO DEL ESCRITORIO";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaTablaDeSimbolos = saveFileDialog1.FileName;

                StreamWriter fichero = new StreamWriter(rutaTablaDeSimbolos);
                fichero.Write(html);
                fichero.Close();
                Process.Start(rutaTablaDeSimbolos);
            }
            else
            {
                saveFileDialog1.Dispose();
                saveFileDialog1 = null;
            }
            
        }

        private void tablaDeSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarTablaDeSimbolos();
            
        }

        private void archivoDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarTablaDeErrores();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Autor: Josué Benjamín Girón Ramírez\nCarné: 201318631\r\n\nUniversidad San Carlos de Guatemala\r\n\nSegundo semestre del año 2017\nCurso: LENGUAJES FORMALES Y DE PROGRAMACION\nCódigo: 796 \nSección: B- \nEdificio: T3 \nSalón: 214 \nCatedrático: ZULMA KARINA AGUIRRE ORDÓÑEZ \nCorreo: aguirrezulma@gmail.com\nAuxiliar: José Velasquez\nCorreo: josevelasquez3064@gmail.com\r\n\nCopyright © Todos los Derechos Reservados.";
            MessageBox.Show(info);
        }

        private void textoentrada1_TextChanged(object sender, EventArgs e)
        {

        }


        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Documentos\\Manual de usuario.pdf");
            Process.Start(pdfPath);
        }

        private void manualTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Documentos\\Manual tecnico.pdf");
            Process.Start(pdfPath);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        /* private Bitmap rotateImage(Bitmap b, double angle)
{
    //create a new empty bitmap to hold rotated image
    Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
    //make a graphics object from the empty bitmap
    Graphics g = Graphics.FromImage(returnBitmap);
    //move rotation point to center of image
    g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
    //rotate
    g.RotateTransform(angle);
    //move image back
    g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
    //draw passed in image onto graphics object
    g.DrawImage(b, new Point(0, 0));
    return returnBitmap;
}*/
    }

}


public class lexema
{
    public int id { get; set; }
    public string idToken { get; set; }
    public string nombre { get; set; }
    public int fila { get; set; }
    public int columna { get; set; }
    public string token { get; set; }
}

public class variable
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string tipo { get; set; }
    public string valor { get; set; }
}


public class error
{
    public int id { get; set; }
    public int fila { get; set; }
    public int columna { get; set; }
    public string caracter { get; set; }
   
}

