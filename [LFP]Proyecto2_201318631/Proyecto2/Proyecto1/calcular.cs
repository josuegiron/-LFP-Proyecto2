using System;
using System.Collections.Generic;

public class Calcular
{
    List<termino> expresion;
    List<variable> tablaVariables;
    List<variable> tablaConstantes;

    public Calcular(List<termino> expresion, List<variable> tablaVariables, List<variable> tablaConstantes)
    {
        this.expresion = expresion;
        this.tablaVariables = tablaVariables;
        this.tablaConstantes = tablaConstantes;
        valor();



}
    public string resultado()
    {
        return valVarC;
    }
    private string obtenerVariable(string nombre)
    {

        variable var = tablaVariables.Find(x => x.nombre.Contains(nombre));
        if (var == null)
        {
            return "";
        }
        else
        {
            return Convert.ToString(var.valor);
        }

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

    public string[,] token = new string[,] {
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

    int numLexema = 0;
    string valVarC = "";
    private Boolean validar(int idToken)
    {
        try
        {
            if (expresion[numLexema].idToken == token[idToken, 0])
            {
                numLexema++;
                
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

    private termino obtenerlexema(int idLexema)
    {
        try
        {
            termino lexema = expresion[idLexema];
            return lexema;
        }
        catch { return null; }

    }
    public void valor()
    {
        
                switch (obtenerlexema(numLexema).idToken)
                {
                    case "1":
                        valVarC = obtenerlexema(numLexema).nomTermino;
                        numLexema++;
                        break;
                    case "2":
                        valVarC = obtenerConstante(obtenerlexema(numLexema).nomTermino);
                        if (valVarC == "")
                        {
                            valVarC = obtenerVariable(obtenerlexema(numLexema).nomTermino);
                        }
                        numLexema++;
                        break;
                    
                        
                    default:
                        valVarC = operacion();
                        break;
           
        }
       
    }
    public string operacion()
    {
        string valor = "";
        switch (obtenerlexema(numLexema).idToken)
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
        }
        return "" + total;
    }

    public string division()
    {
        double total = 0;
        if (validar(29))
        {
            string[,] valor = operacionBinaria();
            try
            {
                total = Convert.ToDouble(valor[0, 0]) / Convert.ToDouble(valor[0, 1]);
            }
            catch {  }
        }
        else
        {
        }
        return "" + total;
    }

    public string potencia()
    {
        double total = 0;
        if (validar(30))
        {
            string[,] valor = operacionBinaria();
            total = System.Math.Pow(Convert.ToDouble(valor[0, 0]), Convert.ToDouble(valor[0, 1]));
        }
        else
        {
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
        }
        return "" + total;
    }

    public string seno()
    {
        double total = 0;
        if (validar(32))
        {
            string valor = operacionUnaria();
            try
            {
                total = System.Math.Sin(Convert.ToDouble(valor) * Math.PI / 180);
            }
            catch {  }
        }
        else
        {
        }
        return "" + total;
    }

    public string coseno()
    {
        double total = 0;
        if (validar(33))
        {
            string valor = operacionUnaria();
            try
            {
                total = System.Math.Cos(Convert.ToDouble(valor) * Math.PI / 180);
            }
            catch {  }
        }
        else
        {
        }
        return "" + total;
    }

    public string tangente()
    {
        double total = 0;
        if (validar(34))
        {
            string valor = operacionUnaria();
            try
            {
                total = System.Math.Tan(Convert.ToDouble(valor) * Math.PI/180);
            }
            catch {  }
        }
        else
        {
        }
        return "" + total;
    }

    public string[,] operacionBinaria()
    {
        string[,] valores = new string[,] { { "", "" }, };
        if (validar(20))
        {

            valores[0, 0] = argumento();

            if (validar(22))
            {
            }
            else
            {
            }

            valores[0, 1] = argumento();

            if (validar(21))
            {
                
            }
            else
            {
            }

        }
        else
        {
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
            valor = argumento();

            if (validar(21))
            {
                
            }
           

        }
        

        if (valor == "")
        {
            valor = "0";
        }
        return valor;
    }

    public string argumento()
    {
        string valor = "";
        switch (obtenerlexema(numLexema).idToken)
        {
            case "1":
                valor = obtenerlexema(numLexema).nomTermino;
                numLexema++;
                break;
            case "2":
                valor = obtenerVariable(obtenerlexema(numLexema).nomTermino);
                if (valor == "")
                    valor = obtenerConstante(obtenerlexema(numLexema).nomTermino);
                numLexema++;
                break;
            case "14":
                obtenerlexema(numLexema).idToken = "2";
                numLexema++;
                break;
            default:
                valor = operacion();
                break;
        }
        return valor;
    }

}
