using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace EfCore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo unico
            //Pego a extensao do arquivo
            //Concateno o nome do arquivo com sua extensao
            //i78967tihuy56r898hjo9743hj.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace(".", "") + Path.GetExtension(file.FileName);

            //.GetCurrentDirectory - Pega o arquivo do diretório atual
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\Imagens", nomeArquivo);

            //Cria um objeto do tipo FileStream passando o tipo de arquivo
            //Passa para criar este arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Executo o comando de criação do aruqivo no local informado 
            file.CopyTo(streamImagem);

            return "https://localhost:44350/upload/imagens/" + nomeArquivo;
        }
    }
}
