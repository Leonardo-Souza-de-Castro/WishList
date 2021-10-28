import './App.css';
import { Component } from "react";

class Cadastro extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idUsuario: 1,
            desejo: '',
            resposta: []
        }
    }

    atualizaEstadoDesejo = async (event) => {
        await this.setState({
            desejo: event.target.value
        })
        console.log(this.state.desejo)
    }

    cadastrar = (event) => {

        console.log("Cadastro iniciado...")

        fetch(`http://localhost:5000/api/Desejos`, {
            method: 'POST',
            body: JSON.stringify({
                idDesejo: 0,
                descricaoDesejo: this.state.desejo,
                idUsuario: this.state.idUsuario,
                idUsuarioNavigation: {
                    idUsuario: 0,
                    email: "",
                    senha: "",
                    desejos: []
                }
            }),
            headers: { 'Content-Type': 'application/json' }
        })
            .then(resposta => this.state.resposta = resposta)
            .catch(erro => console.log(erro))

        console.log(this.state.resposta)
    }



    render() {
        if (this.state.idUsuario != null) {
            return (
                <form onSubmit={this.cadastrar} class="cadastroDesejo">
                    <div>
                        <label>Digite abaixo sua wish</label>
                        <textarea type="text" id="wish" onChange={this.atualizaEstadoDesejo} placeholder="" />
                        <input class="botao" type="submit" placeholder="Desejar" />
                    </div>
                </form>)

        } else {
            return (
                null
            )
        }
    }
}

class Wish extends Component {
    constructor(props) {
        super(props)
        this.state = {
            listaWishs: [],
        }
    }

    salvarDesejos = () => {

        fetch(`http://localhost:5000/api/Desejos/Listar`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        })
            .then(dados => dados.json())
            .then(dados => this.setState({ listaWishs: dados }))
            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.salvarDesejos()
    }

    render() {
        return (
            <section>
                {
                    this.state.listaWishs.map((wish) => {
                        return (
                            <div>
                                <div>{wish.idUsuario}</div>
                                <div class="wish">{wish.descricaoDesejo}</div>
                            </div>
                        )
                    })
                }

            </section>
        )
    }
}

function App() {
    return (
        <div>
            <header>

                <p>Listagem</p>
                <p>Wish</p>
                <a class="link" href="http://localhost:3000/">Login</a>

            </header>
            <body class="body container">
                <Cadastro />
                <Wish />
            </body>
            <footer class="container">
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