# Projeto de Análise e Visualização de Microdados do ENEM

## Diagramas

### Diagrama de Casos de Uso

Justificativa: Esse diagrama é essencial para representar as interações entre os atores (usuários e sistemas) e o sistema em questão. Ele fornece uma visão clara e compreensível dos requisitos funcionais do sistema, mostrando as funcionalidades que serão disponibilizadas para os usuários e como essas funcionalidades se relacionam.

[![Diagrama de Casos de Uso](url-diagrama-casos-uso)](https://drive.google.com/file/d/14XU0zB-0w8dKnFdHGPR_eDQMcI9t_4b_/view?usp=sharing)

### Diagrama de Classes

Justificativa: O Diagrama de Classes é utilizado para representar a estrutura estática do sistema, mostrando as classes, seus atributos, métodos e os relacionamentos entre elas. Ele é fundamental para compreender a organização das entidades no sistema, facilitando a modelagem e o entendimento do domínio do problema.

[![Diagrama de Classes](url-diagrama-classes)](https://drive.google.com/file/d/14nsvyZMTRXuQuRz11wPsLyrazVrgXExW/view?usp=sharing)

### Diagrama de Sequência

Justificativa: Esse diagrama facilita a comunicação entre a equipe ao mostrar a ordem das mensagens trocadas entre objetos, proporcionando uma visão temporal das operações.

#### Cenário: Usuário Comum

[![Diagrama de Sequência - Usuário Comum](url-diagrama-sequencia-usuario-comum)](https://drive.google.com/file/d/1dAMLaNPf86tFDw_ZtcaVhYI2iEQ0GbGZ/view?usp=sharing)

#### Cenário: Administrador

[![Diagrama de Sequência - Administrador](url-diagrama-sequencia-administrador)](https://drive.google.com/file/d/1p88UYPXfycYA5wjjKJSN7DsCQBaEuoZ3/view?usp=sharing)

## Modelo de Dados

### Modelo Conceitual

[![Modelo Conceitual](url-conceitual)](https://drive.google.com/file/d/14fcoPz3sAHZ4ruhLuMjOZgn3qYZ0gc4H/view?usp=sharing)

#### Identificação de Entidades

- Participante; Usuario; Escolaridade; LocalDeAplicacao; ProvaPorArea; 

#### Identificação de Atributos

## Participante
- **Atributos:**
  - NumeroInscricao: string
  - AnoEnem: int
  - FaixaEtaria: string
  - Sexo: string
  - EstadoCivil: string
  - Raca: string
  - Nacionalidade: string
  - Treineiro: boolean

## Usuario
  - **Atributos:**
    - IsAdministrador: bool
    - Nome: string
    - Email: string
    - Senha: char

## Escolaridade
- **Atributos:**
  - NumeroInscricao: string
  - SituacaoConclusao: string
  - AnoConclusao: int
  - TipoEscola: string
  - TipoEnsino: string
  - CodigoEscola: string
  - NomeMunicipio: string
  - CodigoMunicipio: int
  - CodigoUF: int
  - SiglaUF: string
  - DependenciaAdministrativa: string
  - ZonaLocalizacao: string
  - SitucaoFuncionamento: string

## LocalDeAplicacao
- **Atributos:**
  - NumeroInscricao: string
  - NomeMunicipio: string
  - CodigoMunicipio: int
  - CodigoUF: int
  - SiglaUF: string

## ProvaAreaConhecimento
- **Atributos:**
  - NumeroInscricao: string
  - PresencaCN: boolean
  - PresencaCH: boolean
  - PresencaLC: boolean
  - PresencaMT: boolean
  - CodTipoProvaCN: int
  - CodTipoProvaCH: int
  - CodTipoProvaLC: int
  - CodTipoProvaMT: int
  - NotaCN: real
  - NotaCH: real
  - NotaLC: real
  - NotaMT: real
  - VetRespCN: string
  - VetRespCH: string
  - VetRespLC: string
  - VetRespMT: string
  - VetGabCN: string
  - VetGabCH: string
  - VetGabLC: string
  - VetGabMT: string
  - LinguaEstrangeira: string

## Redacao
- **Atributos:**
  - NumInscricao
  - StatusRedacao: string
  - NotaComp1: real
  - NotaComp2: real
  - NotaComp3: real
  - NotaComp4: real
  - NotaComp5: real
  - NotaRedacao: real


### Modelo Físico

- O modelo físico de dados é crucial para representar a estrutura de dados de forma detalhada e específica para um sistema de banco de dados. Ele inclui informações como tipos de dados, chaves primárias, chaves estrangeiras, restrições de integridade, índices e outras características específicas do banco de dados. Ao transformar o modelo conceitual em um modelo físico, estamos traduzindo a visão de alto nível em algo que pode ser implementado diretamente no sistema de gerenciamento de banco de dados (SGBD).
- [![Modelo Físico](url-físico)](https://drive.google.com/file/d/14gMYCMkViRwF2DeJm9jJBEJWgNZ60j-G/view?usp=sharing)


### Participantes

- CÍCERO MIGUEL DA SILVA
- FELIPE SANTOS ROCHA
- GUILHERME FONTES DE JESUS 
- LUAN FABRICIO DE CARVALHO
- NICEU SANTOS BIRIBA

### Link do projeto disponível no google drive

[![Projeto no Google Drive](url-gd)](https://docs.google.com/document/d/1C5fU20dS7DPIUfHb00cluzG7viHoEDgtuZTgfECfXYU/edit#heading=h.w7vclt5z8ke6)


