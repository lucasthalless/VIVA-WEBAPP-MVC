# VIVA - Vigilância Integrada para Vidas Atingidas

> _API REST_

VIVA é uma plataforma que combina monitoramento ambiental, comunicação comunitária de emergência e gestão de riscos, tudo de forma acessível, resiliente e independente das grandes infraestruturas.

Nosso objetivo é oferecer uma rede de apoio que funcione mesmo quando internet, sinal de celular e energia falham, colocando a vida e o cuidado coletivo no centro da solução.

![pilares.jpg](https://github.com/lucasthalless/VIVA-WEBAPP-MVC/blob/main/VIVA-WEBAPP-MVC/wwwroot/pilares.jpg)

## 📘 Documentação da API

Base URL: `http://localhost:5233/api`

---

### 🔹 `SolicitacaoDeAjuda`

#### ▶️ `GET /solicitacaoDeAjuda`
Retorna todas as solicitações de ajuda.

```
GET http://localhost:5233/api/solicitacaoDeAjuda
```

#### ▶️ `GET /solicitacaoDeAjuda/{id}`
Retorna uma solicitação específica pelo ID.

```
GET http://localhost:5233/api/solicitacaoDeAjuda/1
```

#### 📤 `POST /solicitacaoDeAjuda`
Cria uma nova solicitação de ajuda.

```
POST http://localhost:5233/api/solicitacaoDeAjuda
Content-Type: application/json

{
  "id": 0,
  "tipoSolicitacao": "string",
  "conteudo": "string",
  "dataHora": "2025-06-08T15:31:59.083Z",
  "status": "string",
  "nivel": "strin",
  "idUsuario": 1
}
```

#### ✏️ `PUT /solicitacaoDeAjuda/{id}`
Atualiza uma solicitação existente.

```
PUT http://localhost:5233/api/solicitacaoDeAjuda/1
Content-Type: application/json

{
  "id": 1,
  "tipoSolicitacao": "Atualizada",
  "conteudo": "Novo conteúdo",
  "dataHora": "2025-06-08T18:00:00.000Z",
  "status": "Resolvido",
  "nivel": "Alto",
  "idUsuario": 1
}
```

#### ❌ `DELETE /solicitacaoDeAjuda/{id}`
Deleta uma solicitação de ajuda.

```
DELETE http://localhost:5233/api/solicitacaoDeAjuda/1
```

---

### 🔹 `Usuario`

#### ▶️ `GET /usuario`
Retorna todos os usuários.

```
GET http://localhost:5233/api/usuario
```

#### ▶️ `GET /usuario/{id}`
Retorna um usuário específico pelo ID.

```
GET http://localhost:5233/api/usuario/2
```

#### 📤 `POST /usuario`
Cria um novo usuário.

```
POST http://localhost:5233/api/usuario
Content-Type: application/json

{
  "id": 0,
  "nome": "João Silva",
  "cpf": "12345678900",
  "telefone": "11999999999",
  "email": "joao@example.com",
  "tipoUsuario": "Comum"
}
```

#### ✏️ `PUT /usuario/{id}`
Atualiza um usuário existente.

```
PUT http://localhost:5233/api/usuario/2
Content-Type: application/json

{
  "id": 2,
  "nome": "João Atualizado",
  "cpf": "12345678900",
  "telefone": "11999999999",
  "email": "joao.novo@example.com",
  "tipoUsuario": "Administrador"
}
```

#### ❌ `DELETE /usuario/{id}`
Deleta um usuário.

```
DELETE http://localhost:5233/api/usuario/2
```

### Requisitos do projeto:

- [ ] API REST que atenda a boas práticas de programação / arquitetura;
- [ ] Persistência em Banco de Dados relacional;
- [ ] Pelo menos um relacionamento 1:N;
- [ ] Documentação com o Swagger;
- [ ] Aplicação de Razor e TagHelpers;
- [ ] Uso correto da Migration no projeto.
