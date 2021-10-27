# WishList
Projeto de um sistema com todas as etapas que contém as funcionalidades de uma Lista de Desejos
# Clonando o Repositódo Github
Para clonar o Repositório do GitHub você precisára verificar se a instalção de git foi feita, e se tudo estiver certo você executara o seguinte comando no terminal do Git: 

git clone https://github.com/Leonardo-Souza-de-Castro/WishList

# Para Criar o Banco de Dados
Para Criar o banco de dados após a clonagem do repositório para a sua máquina, você devera abrir o SQL Server Management Studio (caso já o tenha instalado, caso contrário o instale).

Lá você ira adicionar os arquivos :

__DiretorioOndeORepositorioFoiClonado\WishList\BD\WishList_01_DDL.sql__

__DiretorioOndeORepositorioFoiClonado\WishList\BD\WishList_01_DML.sql__

__DiretorioOndeORepositorioFoiClonado\WishList\BD\WishList_01_DQL.sql__

Agora com os arquivos adicionados você ira primeiro no arquivo denominado DDL e clicara em Executar assim serão criados o banco e as tabelas.

Em seguida você abrirá o arquivo denominado DML e novamente clicara em executar assim você adicionara os valores as tabelas

E por fim você realizara o mesmo processo com o arquivo subsequente para ver as tabelas é para aparecer algo semelhante a isso:

Id_Desejo     | Descricao_Desejo                     | Id_Usuario
:-----------: | :----------------------------------: | :----------:
1             | Queria ter uma casa nova             | 1
2             | Queria um air jordan 1 royal blue    | 2
3             | Adoraria ter uma Porsche             | 1
4             | Queria um joia do Saulo              | 1

# Importando a coleção para o Postman
Primeiro você devera verificar se o Postman esta instalado, caso esteja você devera clicar no botão de importar e selecionar o arquivo:

__DiretorioOndeORepositorioFoiClonado\WishList\Back-End\Postman\Senai_WishList_webAPI.postman_collection__

Com o arquivo importado deve vir a seguinta coleção:

* Login:
   * Login
* Desejos:
   * Desejos.Listar
   * Deejos.ListarMinhas
   * Desejo.Cadastrar

# Executando a API
Primeiramente você deve acessar o arquivo WishListContext e mudar o lugar onde esta escrito options builder para o seu computador, o seu banco com a sua senha de acesso.

Ex: ` optionsBuilder.UseSqlServer("Data Source=NOTE0113F1\\SQLEXPRESS; initial catalog=WishList; user Id=sa; pwd=Senai@132;");
            }`

Após isso para executar a API temos 2 opções:

__Primeira:__ Você pode abrir o local do arquivo (__DiretorioOndeORepositorioFoiClonado\WishList\Back-End\Senai_WishList_webAPI__) e na parte superior onde fica a rota dele digitar cmd e depois colocar um dotnet run e dar enter.

__Segunda:__ Abra o arquivo DiretorioOndeORepositorioFoiClonado\WishList\Back-End\Senai_WishList_webAPI\Senai_WishList_webAPI.sln no Visual Studio e clique em executar Senai_WishList_webAPI.

Após realizar a execução da API você já pode testar os métodos no Postman.

# Para rodar a Aplicação Web
Primeiramente você devera instalar as dependecias do projeto e para isso você devera acessar:

__DiretorioOndeORepositorioFoiClonado\WishList\Front End\WishList__

E na parte superior digitar cmd e colocar o comando `npm i` ou  `nom instal`

Após isso a aplicação pode ser executada de duas maneiras sendo elas:

__Primeira:__ Você pode abrir o local do arquivo (__DiretorioOndeORepositorioFoiClonado\WishList\Front End\WishList__) e na parte superior onde fica a rota dele digitar cmd e depois colocar um npm start e dar enter.

__Segunda:__ Você pode abrir o local do arquivo (__DiretorioOndeORepositorioFoiClonado\WishList\Front End\WishList__) no Visual Studio Code e abrir o prompt de comando (ctrl + ') e digitar o comando npm start.

O projeto sera aberto em uma nova aba com a rota sendo locallhost:3000 e seus variantes.
