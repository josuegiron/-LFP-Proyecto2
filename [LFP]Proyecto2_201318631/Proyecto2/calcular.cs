using System;

public class Calcular
{
    List<termino> expresion;

    public Calcular(List<termino> expresion)
    {
        this.expresion = expresion;
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
                        if (valVarC == "")
                        {
                            valVarC = obtenerVariable(obtenerlexema(numLexema + 1).nombre);
                        }
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
                escribirEnConsola("- ERROR SINTACTICO: Se esperaba '=' " + error(numLexema));
            }

        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba un 'valor'" + error(numLexema));
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
                escribirEnConsola("- ERROR SINTACTICO: Se esperaba numero, Id, cadena de caracteres o una operacion" + error(numLexema));
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
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Suma'" + error(numLexema));
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
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Resta'" + error(numLexema));
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
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Multiplicar'" + error(numLexema));
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
            catch { escribirEnConsola("No se puede valuar la funcion."); }
        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Dividir'" + error(numLexema));
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
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Potencia'" + error(numLexema));
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
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'RaizCuadrada'" + error(numLexema));
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
                total = System.Math.Sin(Convert.ToDouble(valor));
            }
            catch { escribirEnConsola("No se puede valuar la funcion."); }
        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Seno'" + error(numLexema));
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
                total = System.Math.Cos(Convert.ToDouble(valor));
            }
            catch { escribirEnConsola("No se puede valuar la funcion."); }
        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Coseno'" + error(numLexema));
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
                total = System.Math.Tan(Convert.ToDouble(valor));
            }
            catch { escribirEnConsola("No se puede valuar la funcion."); }
        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba 'Tangente'" + error(numLexema));
        }
        return "" + total;
    }

    public string[,] operacionBinaria()
    {
        agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
        string[,] valores = new string[,] { { "", "" }, };
        if (validar(20))
        {
            agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);

            valores[0, 0] = argumento();

            if (validar(22))
            {
                agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
            }
            else
            {
                escribirEnConsola("- ERROR SINTACTICO: Se esperaba ','" + error(numLexema));
            }

            valores[0, 1] = argumento();

            if (validar(21))
            {
                if (obtenerlexema(numLexema).idToken == "50" | obtenerlexema(numLexema).idToken == "24")
                {
                    agregarTermino(obtenerlexema(numLexema - 1).idToken, obtenerlexema(numLexema - 1).nombre);
                }
                else
                {
                    agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
                }
            }
            else
            {
                escribirEnConsola("- ERROR SINTACTICO: Se esperaba ')'" + error(numLexema));
            }

        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba '('" + error(numLexema));
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
        agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
        string valor = "";
        if (validar(20))
        {
            agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
            valor = argumento();

            if (validar(21))
            {
                if (obtenerlexema(numLexema).idToken == "50" | obtenerlexema(numLexema).idToken == "24")
                {
                    agregarTermino(obtenerlexema(numLexema - 1).idToken, obtenerlexema(numLexema - 1).nombre);
                }
                else
                {
                    agregarTermino(obtenerlexema(numLexema).idToken, obtenerlexema(numLexema).nombre);
                }
            }
            else
            {

                escribirEnConsola("- ERROR SINTACTICO: Se esperaba ')'" + error(numLexema));
            }

        }
        else
        {
            escribirEnConsola("- ERROR SINTACTICO: Se esperaba '('" + error(numLexema));
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
        switch (obtenerlexema(numLexema + 1).idToken)
        {
            case "1":
                agregarTermino(obtenerlexema(numLexema + 1).idToken, obtenerlexema(numLexema + 1).nombre);
                valor = obtenerlexema(numLexema + 1).nombre;
                numLexema++;
                break;
            case "2":
                agregarTermino(obtenerlexema(numLexema + 1).idToken, obtenerlexema(numLexema + 1).nombre);
                valor = obtenerVariable(obtenerlexema(numLexema + 1).nombre);
                if (valor == "")
                    valor = obtenerConstante(obtenerlexema(numLexema + 1).nombre);
                numLexema++;
                break;
            case "14":
                agregarTermino(obtenerlexema(numLexema + 1).idToken, obtenerlexema(numLexema + 1).nombre);
                obtenerlexema(numLexema + 1).idToken = "2";
                agregarTermino(obtenerlexema(numLexema + 1).idToken, obtenerlexema(numLexema + 1).nombre);
                numLexema++;
                break;
            default:
                valor = operacion();
                break;
        }
        return valor;
    }

}
