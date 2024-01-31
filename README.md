# Projeto de Análise e Visualização de Microdados do ENEM

## Diagramas

### Diagrama de Casos de Uso

Justificativa: Esse diagrama é essencial para representar as interações entre os atores (usuários e sistemas) e o sistema em questão. Ele fornece uma visão clara e compreensível dos requisitos funcionais do sistema, mostrando as funcionalidades que serão disponibilizadas para os usuários e como essas funcionalidades se relacionam.

[![Diagrama de Casos de Uso](url-diagrama-casos-uso)](https://drive.google.com/file/d/14XU0zB-0w8dKnFdHGPR_eDQMcI9t_4b_/view?usp=sharing)

### Diagrama de Classes

Justificativa: O Diagrama de Classes é utilizado para representar a estrutura estática do sistema, mostrando as classes, seus atributos, métodos e os relacionamentos entre elas. Ele é fundamental para compreender a organização das entidades no sistema, facilitando a modelagem e o entendimento do domínio do problema.

![Diagrama de Classes](url-diagrama-classes)

### Diagrama de Sequência

Justificativa: Esse diagrama facilita a comunicação entre a equipe ao mostrar a ordem das mensagens trocadas entre objetos, proporcionando uma visão temporal das operações.

#### Cenário: Usuário Comum

[![Diagrama de Sequência - Usuário Comum](url-diagrama-sequencia-usuario-comum)](https://drive.google.com/file/d/1dAMLaNPf86tFDw_ZtcaVhYI2iEQ0GbGZ/view?usp=sharing)

#### Cenário: Administrador

[![Diagrama de Sequência - Administrador](url-diagrama-sequencia-administrador)](https://drive.google.com/file/d/1p88UYPXfycYA5wjjKJSN7DsCQBaEuoZ3/view?usp=sharing)

## Modelo de Dados

### Modelo Conceitual

[https://drive.google.com/file/d/14fcoPz3sAHZ4ruhLuMjOZgn3qYZ0gc4H/view?usp=sharing](https://drive.google.com/file/d/14fcoPz3sAHZ4ruhLuMjOZgn3qYZ0gc4H/view?usp=sharing)

#### Identificação de Entidades

- Aluno; Usuario; Escolaridade; Inscricao; Escola; ProvaPorArea; Redacao

#### Identificação de Atributos

### Aluno
- **Atributos:**
  - Sexo: string
  - EstadoCivil: int
  - Raca: int
  - Nacionalidade: int
  - FaixaEtaria: int

### Usuario
- **Atributos:**
  - Administrador: bool
  - Nome: string
  - Email: string
  - Senha: char

### Escolaridade
- **Atributos:**
  - Concluiu: bool
  - AnoConclusao: int

### Inscricao
- **Atributos:**
  - Matricula: string
  - Treineiro: bool

### Escola
- **Atributos:**
  - Nome: string
  - UF: string
  - Municipio: string

### ProvaAreaConhecimento
- **Atributos:**
  - AreaConhecimento: string
  - Nota: int
  - Presente: bool

### Redacao
- **Atributos:**
  - Nota: int
  - Presente: bool
  - Competencia1: int
  - Competencia2: int
  - Competencia3: int
  - Competencia4: int
  - Competencia5: int


#### Identificação de Relacionamentos

Aluno e Inscricao: 1 para 1 (um para um).
Aluno e Escolaridade: 1 para 1 (um para um).
Inscricao e Escola: M para 1 (muitos para um) - uma escola pode ter várias inscrições.
Inscricao e ProvaArea: 1 para N (um para muitos) - uma inscrição pode ter várias áreas de conhecimento.
            Inscricao e Redacao: 1 para 1 (um para um).


### Modelo Físico

- Detalhes sobre a criação do banco de dados...

