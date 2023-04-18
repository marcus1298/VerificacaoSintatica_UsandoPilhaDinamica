using System;
using System.Collections.Generic;

namespace VerificacaoSintatica
{
    class Program
    {
        static void Main(string[] args)
        {
            string expr1 = "{5* [a+b] -d * (c-a) + log10}";
            string expr2 = "{5*[a+b]-d*(c-a)+log10}";

            Console.WriteLine("Verificando a expressão 1:");
            if (VerificarExpressao(expr1))
            {
                Console.WriteLine("A expressão é válida!");
            }
            else
            {
                Console.WriteLine("A expressão é inválida!");
            }

            Console.WriteLine("\nVerificando a expressão 2:");
            if (VerificarExpressao(expr2))
            {
                Console.WriteLine("A expressão é válida!");
            }
            else
            {
                Console.WriteLine("A expressão é inválida!");
            }
        }

        // Método que verifica se uma expressão está sintaticamente correta
        static bool VerificarExpressao(string expressao)
        {
            Stack<char> pilha = new Stack<char>(); // pilha para armazenar os caracteres abertos

            foreach (char c in expressao)
            {
                if (c == '(' || c == '[' || c == '{') // se é um caractere aberto
                {
                    pilha.Push(c); // adiciona na pilha
                }
                else if (c == ')' || c == ']' || c == '}') // se é um caractere fechado
                {
                    if (pilha.Count == 0) // se a pilha estiver vazia
                    {
                        return false; // expressão é inválida
                    }
                    char topo = pilha.Peek(); // obtém o caractere aberto mais recente
                    if ((c == ')' && topo == '(') || (c == ']' && topo == '[') || (c == '}' && topo == '{')) // se é um par válido
                    {
                        pilha.Pop(); // remove o caractere aberto da pilha
                    }
                    else
                    {
                        return false; // expressão é inválida
                    }
                }
            }

            return pilha.Count == 0; // se a pilha está vazia, a expressão é válida
        }
    }
}