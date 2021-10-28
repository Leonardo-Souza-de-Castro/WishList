import './App.css';
import Desejos from '../listagem/App';
import img from "./img.png";
import { React, Component, } from "react";
import { Redirect } from 'react-router-dom';


class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      resposta: [],
      email: '',
      senha: '',
      validacao: false
    }
  }
  login = () => {

    console.log('Login iniciado!')
    console.log(this.state.email)
    console.log(this.state.senha)

    fetch(`http://localhost:5000/api/Login`, {
      method: 'POST',
      body: JSON.stringify({ Email: this.state.email, Senha: this.state.senha }),
      headers: { 'Content-Type': 'application/json' }
    })
      .then(dados => dados.json())
      .then(dados => this.state.resposta = dados)
      .catch(erro => console.log(erro))

    if (this.state.resposta.token != null) {
      Desejos.setState({
        email: this.state.email,
        validacao: true
      })

    } else {
      console.log('Email ou senha incorretos.')

    }
  }

  atualizaEstadoEmail = async (event) => {
    await this.setState({
      email: event.target.value
    })
    console.log(this.state.email)
  }

  atualizaEstadoSenha = async (event) => {
    await this.setState({
      senha: event.target.value
    })
    console.log(this.state.senha)
  }


  render() {
    if (this.state.validacao == true) {
      return <Redirect to="/wish/" />
    }
    else {
      return (

        <form //onSubmit={this.login}
          className="login">
          <div>
            <h1>Logar</h1>
            <input type="text" placeholder="E-mail" onChange={this.atualizaEstadoEmail} />
            <input type="password" placeholder="Senha" onChange={this.atualizaEstadoSenha} />
            <input className="button" type="submit" onClick={this.login} placeholder="Entrar" />
          </div>
        </form>
      )
    }
  }
}

function App() {
  return (
    <div>
      <header>
        <p>Listagem</p>
        <p>Wish</p>
        <p>Login</p>
      </header>
      <body className="corpo container">
        <img className="wishlist" src={img} alt="" />
        <Login />
      </body>
      <footer className="container">
        <div>
          <span>Links Úteis</span>
          <a href="#">Regras de utilização</a>
          <a href="#">Suporte</a>
          <a href="#">Central de ajuda</a>
          <a href="#">Mande nos uma mensagem</a>
        </div>
        <span>WISHLIST. Todos os direitos reservados.</span>
      </footer>
    </div>
  );
}

export default App;
