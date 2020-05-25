# ValidaSenha

Esta é uma simples API para validação de senha que responde se a string recebida atende aos critérios para considerá-la válida. 

![](https://github.com/feokuma/ValidaSenha/.github/workflows/dotnet-core.yml/badge.svg)

### Regras
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial

**Exemplo:**  
```
IsValid("") -> false  
IsValid("aa") -> false  
IsValid("ab") -> false  
IsValid("AAAbbbCc") -> false  
IsValid("AbTp9!foo") -> true  
```

## Pré-requisitos

- Dotnet core 3.1

## Ferramentas

- Visual Studio / Visual Studio for Mac / Rider
- Postman / Insomnia
- Terminal
- Git

## Executando o projeto

Certifique-se que está com o dotnet core 3.1. Utilizando um terminal execute o seguinte comando:
```
dotnet --version
```
o resultado deve ser uma versão 3.1.xxx

### Executando os projetos de teste

Na Solution há dois projetos de teste, um de unidade e outro de integração. Para executá-los, utilizando um termnal, navegue até o diretório raiz do projeto e execute o seguinte comando:
```
dotnet test
```
Um saída semelhante a seguinte deverá aparecer no terminal com os resultados dos testes

```console
...
Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 6
     Passed: 6
 Total time: 1.0125 Seconds

Test Run Successful.
Total tests: 11
     Passed: 11
 Total time: 1.2782 Seconds
```

### Executando o projeto da API

Para execução do projeto da API, utilizando um terminal, navegue até o diretório raiz do projeto e execute o seguinte comando:
```
dotnet run --project ./src/ValidaSenha.csproj
```
A seguinte informação deverá aparecer no terminal:
```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
```

### Consultando documentação da API(Swagger)

Com a API em execução, em um browser, acesse [https://localhost:5001](https://localhost:5001/) para entra na página do Swagger onde será possivel ver informações sobre os endpoints, que neste caso é apenas um, e até fazer testes.

### Enviando uma string para teste

É possível enviar uma string para a validação dos critérios da senha através do próprio swagger, ou utilizando alguma ferramenta REST Client como [Postman](https://www.postman.com/) ou o [Insomnia](https://insomnia.rest/). 

Utilizando o Postman, que é meu favorito, siga os seguintes passos para enviar o teste:
1) Vá em **Preferences**, na guia **General** e desabilite a opção **SSL Certificate verification**. Isso é necessário pois não estamos utilizando um certificado e o postman não fará a requisição se estiver levando isso em conta.
2) Na área principal crie uma nova aba e no método onde está **GET**, altere para **POST**
3) No campo para URL insira `https://localhost:5001/api/validasenha`
4) Nas guias abaixo selecione **Body** e nas opções que aparecerão abaixo selecione **raw**. No combo no final desta linha de opções onde está **Text** altere para **JSON**
5) No campo de seguinte insira a estrutura com a string que deseja testar
```
{
  "input": "AbTp9!foo"
}
```
6) Clique no botão **Send**. A resposta da requisição surgirá em um campo abaixo
```
{
  "output": true
}
```
O retorno do output será **true** quando a senha atender às [regras](#regras) e **false** quando não atender a uma ou mais regras.    
