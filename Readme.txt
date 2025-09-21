# Projeto "Ludoteca .NET"

## 📖 Descrição do Projeto

[cite_start]Este é um aplicativo de console desenvolvido em C# para o controle de empréstimo de jogos de tabuleiro de um clube universitário[cite: 4]. O sistema permite cadastrar jogos e membros, registrar empréstimos e devoluções, e persistir todos os dados em um arquivo JSON para que as informações não sejam perdidas ao fechar o programa.

Este projeto corresponde à entrega da **AV1**.

## 👥 Integrantes

| Nome Completo | Matrícula |
| Lucas Gabriel Simões Marinho | 06009936 |
| Julia Scarpi Campos | 06006846 |
| Flora Martins Di Risio Pinheiro | 06010591 |
| Emanuel De Oliveira Freitas Branco | 06010524 |


## ✨ Funcionalidades (AV1)

[cite_start]O programa implementa as seguintes funcionalidades obrigatórias[cite: 22]:

* **Cadastro de Jogos:** Permite adicionar novos jogos ao acervo da ludoteca.
* **Cadastro de Membros:** Permite registrar novos membros aptos a pegar jogos emprestados.
* **Listagem de Jogos e Membros:** Exibe todos os jogos (com status de disponibilidade) e membros cadastrados.
* [cite_start]**Empréstimo de Jogos:** Associa um jogo a um membro, alterando seu status para "Emprestado" e bloqueando novas retiradas[cite: 23].
* **Devolução de Jogos:** Libera um jogo anteriormente emprestado, tornando-o "Disponível" novamente.
* [cite_start]**Persistência de Dados:** Salva e carrega o estado da ludoteca (jogos, membros e empréstimos) no arquivo `biblioteca.json`[cite: 25].
* **Tratamento de Exceções:** Lida com erros de entrada do usuário e regras de negócio (ex: tentar emprestar um jogo indisponível) de forma controlada.

## 🚀 Como Executar o Projeto

Para compilar e executar a aplicação, utilize os seguintes comandos no terminal, a partir da pasta raiz do projeto:

```bash
# Para construir o projeto
dotnet build

# Para executar o projeto
dotnet run
```
[cite_start]O projeto deve compilar e rodar sem erros para que a avaliação seja possível[cite: 41].

## 📋 Artefatos e Marcações da AV1

Conforme solicitado nos critérios de avaliação, aqui estão os guias para os artefatos e marcações de código.

### 1. Diagrama UML

O diagrama de classes UML, que modela as classes `Jogo`, `Membro`, `Emprestimo` e `Biblioteca`, pode ser encontrado no seguinte arquivo:
* [cite_start]`/diagrama-uml.png` [cite: 39]

### 2. Vídeo de Apresentação

O vídeo de demonstração do sistema (duração máxima de 10 minutos) está disponível no link abaixo:
* [cite_start]**(EDITAR) Link para o seu vídeo no YouTube, Loom, etc.** [cite: 39]

### 3. Localização das Validações e Encapsulamento

[cite_start]As validações nos construtores e o encapsulamento das propriedades (`private set`) estão localizados nos seguintes pontos[cite: 39]:

* **Classe `Jogo.cs`**:
    * **Construtor e Validações:** Linhas 8-20
    * **Propriedades Encapsuladas:** Linhas 3-6
* **Classe `Membro.cs`**:
    * **Construtor e Validações:** Linhas 5-33
    * **Propriedades Encapsuladas:** Linhas 3-4

### 4. Localização das Marcações no Código

[cite_start]As marcações exigidas para a avaliação estão nos seguintes arquivos e linhas[cite: 61]:

| Marcação | Descrição | Arquivo | Linhas |
| :--- | :--- | :--- | :--- |
| `// [AV1-3]` | Serialização e Desserialização JSON | `Biblioteca.cs` | 27 e 48 |
| `// [AV1-5]` | Tratamento de Exceções (`try/catch`) | `Program.cs` | 27, 57, 126, 160 |