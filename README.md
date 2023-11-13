# Loja_EcommerceBlazor

Visão Geral

Este é uma implementação em Blazor de uma arquitetura em camadas baseada em Clean Architecture, com a adoção de boas práticas do Domain-Driven Design (DDD). Ele é composto por diversos projetos, cada um desempenhando um papel específico no ecossistema da aplicação.

Estrutura do Projeto

1. Projeto Model
Contém as entidades e objetos de valor que representam o domínio da aplicação. Essas classes refletem as regras de negócio e são usadas em várias camadas.

2. Projeto DTO
Engloba Data Transfer Objects (DTOs) que facilitam a transferência de dados entre camadas. Essa separação contribui para uma comunicação eficiente entre a API e o front-end.

3. Projeto Repositório
Responsável pela interação com o armazenamento de dados. Implementa interfaces definidas na camada de serviço para acesso a dados.

4. Projeto Serviço
Contém a lógica de negócios da aplicação. Aqui, as operações de domínio são implementadas, utilizando as entidades do Projeto Model e acessando dados por meio do Projeto Repositório.

5. Projeto Utilidades
Inclui utilitários e ferramentas auxiliares necessárias para funcionalidades comuns em todo o projeto. uma delas é o AutoMapper.

6. Projeto API
Fornece interfaces de programação de aplicativos (APIs) que serão consumidas pelo front-end. Este projeto é crucial para garantir uma separação clara entre a lógica de negócios e a interface do usuário.

7. Projeto Front-end (WebAssembly Blazor)
Utiliza a tecnologia Blazor WebAssembly para criar uma aplicação front-end interativa e responsiva. Este projeto consome as APIs fornecidas pelo Projeto API, garantindo uma comunicação eficiente com o back-end.

Como Iniciar
Requisitos Prévios

Certifique-se de ter as dependências necessárias instaladas.
Inicie primeiro o Projeto API e, em seguida, inicie o projeto Blazor WebAssembly.

Contribuições
Toda e qualquer contribuição ou interesse é bem-vindo! 
Pode me contactar pelos contactos a baixo:

Email: 
Eng.leomazenda@gmail.com

Telefones:
+244 923 684 849 - (se for pelo WhatsApp é este)
+244 956 099 039

Linkedin: 
Leonildo Vivaldo MAzenda 
Link => https://www.linkedin.com/in/leonildo-vivaldo-mazenda-202121210/

FaceBook: 
Leonildo Vivaldo 
Link => https://web.facebook.com/leonildo.vivaldo

