﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Jobx.Servicos.Validation
{
    public class CPFValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return true;
                }
                else
                {
                    int[] d = new int[14];
                    int[] v = new int[2];
                    int j, i, soma;
                    string SoNumero;

                    SoNumero = Regex.Replace(value.ToString(), "[^0-9]", string.Empty);

                    //verificando se todos os numeros são iguais
                    if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

                    // se a quantidade de dígitos numérios for igual a 11
                    // iremos verificar como CPF
                    if (SoNumero.Length == 11)
                    {
                        for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                        for (i = 0; i <= 1; i++)
                        {
                            soma = 0;
                            for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                            v[i] = (soma * 10) % 11;
                            if (v[i] == 10) v[i] = 0;
                        }
                        return (v[0] == d[9] & v[1] == d[10]);
                    }

                    // CPF ou CNPJ inválido se
                    // a quantidade de dígitos numérios for diferente de 11 e 14
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}