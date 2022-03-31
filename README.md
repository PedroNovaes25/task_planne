# API Planilha gerenciadora

### Introdução

A API planilha representa um software de gerenciamento de tarefas, onde você pode criar quadros com “N” tarefas e definir se uma tarefa foi iniciada, concluída ou se ela apenas foi definida no escopo. 

### Acesso à documentação detalhada

Para acessar a documentação Swagger, basta executar a API que logo será aberto uma documentação com mais detalhes e opção de fazer requisições das chamadas disponíveis.

### Controllers

Esta API possui duas controllers, que fornecem as funcionalidades citadas anteriormente.

**API/QuadrosController**

A Controller Quadro representa um quadro de tarefas, onde você pode; criar quadro, listar quadros, obter quadro por id, excluir um quadro junto com suas tarefas e atualizar um quadro.

**API/TarefasController**

A Controller tarefa como o próprio nome diz, representa uma tarefa, onde podem ser feitas operações de; criar tarefa, excluir tarefa, obter uma tarefa pelo id e atualizar tarefa

**Funcionamento**

Primeiramente é necessário criar Um quadro de tarefas pela controller Quadro, depois disso, pela controller tarefas, é possivel criar 'n' tarefas e associar ao id do quadro criado.
É possível cria 'n' quadros, e cada quadro pode ter 'n' tarefas.

### Detalhes 

**Arquitetura** 

Mesmo sendo um projeto pequeno, optei por usar Clean architecture para simular um pouco de uma aplicação que pode ter seu core reutilizado ao separar em camadas e também segui os princípios SOLID Como interface e inversão de dependência, para que seja possível uma mudança na implementação da persistência e da aplicação.

