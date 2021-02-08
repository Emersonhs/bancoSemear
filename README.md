<p align="center"><img src="https://www.bancosemear.com.br/assets/application/img/logo_banco_semear.png" width="150" /></p>
<h1 align="center">Banco Semear teste DevOps</h1>

Eu criei um pipeline de integração continua no Azure DevOps para fazer o deploy em um serviço no fargate e em um 
bucket S3 na AWS.
<pre>
1 - Para fazer o teste foram criados 2 repositorios no GitHub: 
    1.1 - Repositorio da API - https://github.com/Emersonhs/bancoSemear.api  
            - esse repositorio tem uma aplicação .Net Core. essa aplicação tem uma rota de API "/bancosemear/healthcheck"  
              que retora uma mensagem simples.
    1.2 - Repositorio da pagina estatica - https://github.com/Emersonhs/bancosemear.staticpage 
            - Esse Repositorio tem um arquivo de uma pagina simples HTML. 

2 - Deploy
    2.1 - Para fazer o Deploy eu usei o Azure DevOps
        - projeto pode ser acessado pelo link: https://dev.azure.com/emersonhsilva/Semear
            - se for necessario os dados de acesso são:
                link: <a href="https://login.microsoftonline.com/common/oauth2/authorize?client_id=499b84ac-1321-427f-aa17-267ca6975798&site_id=501454&response_mode=form_post&response_type=code+id_token&redirect_uri=https%3A%2F%2Fapp.vssps.visualstudio.com%2F_signedin&nonce=56bd899d-f791-4678-b237-e28d1151aff1&state=realm%3Ddev.azure.com%26reply_to%3Dhttps%253A%252F%252Fdev.azure.com%252F%26ht%3D3%26nonce%3D56bd899d-f791-4678-b237-e28d1151aff1%26githubsi%3Dtrue%26WebUserId%3D1BF3979401796E1D2270984C00EF6F64&resource=https%3A%2F%2Fmanagement.core.windows.net%2F&cid=56bd899d-f791-4678-b237-e28d1151aff1&wsucxt=1&githubsi=true&msaoauth2=true"> Azure DevOps</a>  
                usuario: ehsdevops@gmail.com
                Senha: @DevOps0011@
    2.2 - Build
        - Todo commit na branch master do repositorio bancoSemear.api dispara o build que gera uma imagem a partir do  DokerFile e publicamos no ECR da AWS
        - alem de criar a iamgem execulta os teste unitarios que pode ser vistos na analise do build : 

    2.3 - Release
        - Semear - API - Assim que o build termina o release dispara e publica o novo container no serviço do ECS no AWS
            - faz um teste no healthcheck para sabermos se a aplicação realmente esta no ar: http://deploysoftware.info/bancosemear/healthcheck
 
        - Semear - Page - dispara a partir de um commit na branch master bancosemear.staticpage
</pre>
<pre>
                            <h2> ARQUITETURA AWS</h2>
    - Foi arquitetado a solução de acordo com a imagem abaixo.

    <img src="https://arquiteturaaws.s3.amazonaws.com/DiagramaBancoSemear.png">

   - A API depode ser acessada pelo link: http://deploysoftware.info/index.html
        - tem uma rota para healthcheck.
   - A Aplicação statica pode ser acessada pelo link: http://deploysoftware.info/index.html/staticpage

    Caso seja necessario acessar o ambiente aws somente leitura com os seguintes dados:
    
        - ID Conta: 474397057832
        - Nome Usuario: SomenteLeitura
        - Senha: @AWS0011@

    OBS: Não foram criados scriptis para automatização de infra estrutura.
    
    Ferramentas e telcnologias usadas
    Desenvolvimento:
        - APi .net Core 3.1 - documentação com Swagger
        - pagina simples com HML
        - Docker 
    CI/CD
        - Azure DevOps
        - Criação imagem docker 
    AWS
        - Route 53
        - Elastic Load balancer
        - ECR
        - Elastic conteiner service 
            - fargate
        - S3 
</pre>






