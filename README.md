## O que foi utilizado
- **Enumeração (`enum`)**: Usada para definir os gêneros literários (`Genero`) que são atribuídos aos livros.
- **Classes**:
  - `Livro`: Representa um livro na biblioteca, contendo título, autor, gênero e quantidade disponível.
  - `Usuario`: Representa um usuário da biblioteca, com nome e lista de livros emprestados.
  - `Biblioteca`: Armazena os livros disponíveis e permite a interação com o catálogo, como cadastro, empréstimo e devolução de livros.
- **Lista (`List<>`)**: Utilizada para armazenar a coleção de livros da biblioteca e os livros emprestados por cada usuário.
- **Tratamento de exceções**: Utilizado no método `CadastrarLivro` para garantir que entradas inválidas sejam tratadas adequadamente.
- **Entrada e saída de dados**: O programa interage com o usuário por meio de inputs e prints no console, solicitando informações sobre livros e usuários.

## Etapas implementadas
1. **Criação de classes** para representar livros, usuários e a biblioteca.
2. **Enumeração de gêneros literários** para facilitar a categorização dos livros.
3. **Métodos de empréstimo e devolução** de livros para gerenciar a quantidade disponível e os empréstimos por usuário.
4. **Interação com o usuário**: Implementação de um menu que permite escolher entre cadastrar, consultar catálogo, emprestar e devolver livros.

## Backlog
1. **Limitar empréstimos simultâneos**: Já existe uma limitação de 3 livros por usuário, mas a funcionalidade pode ser expandida para exibir quais livros o usuário já pegou emprestado.
2. **Relatório de livros emprestados**: Criar um método que exibe todos os livros atualmente emprestados por um usuário.
3. **Validação de entradas**: Adicionar validações mais robustas para garantir que as entradas do usuário sejam consistentes (por exemplo, evitar entrada de quantidade negativa).
4. **Persistência de dados**: Salvar o catálogo de livros e os dados dos usuários em arquivos para que o sistema não perca informações ao ser fechado.

## Conclusão
O sistema básico de biblioteca foi implementado com sucesso. Ele permite a gestão de um catálogo de livros, além de possibilitar que usuários emprestem e devolvam livros. O código está funcional e preparado para futuras expansões, como a adição de persistência de dados e melhorias no controle de empréstimos.
