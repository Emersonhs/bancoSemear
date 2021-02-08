<p align="center"><img src="https://www.bancosemear.com.br/assets/application/img/logo_banco_semear.png" width="150" /></p>
<h1 align="center">Banco Semear teste DevOps</h1>

ARQUITETURA
<img src="https://arquiteturaaws.s3.amazonaws.com/DiagramaBancoSemear.png">

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
        - o build e E feito usando o DokerFile que gera a imagem e publicamos no ECR da AWS


</pre>



Repositorio que fiz o Fork do projeto de teste
       - https://github.com/Emersonhs/DevOpsChallenge
Projeto Azure DevOps: 
       -  https://niboteste.visualstudio.com/DevOps
       
    Existem dois builds:
      Build 1 - Nibo Web App - esse fa um build roda os testes automatizados e ativa uma release que vai fazer um Deploy em um ambiente de HML e se o teste de Healthcheck passar ele faz o Deploy em 
                                ambiente de produção.
                                URLs
                                    URL Index
                                        - HML - https://nibowebapp-hml.azurewebsites.net/
                                        - PRD - https://nibowebapp.azurewebsites.net/
                                    URL Healthcheck
                                        - Healthcheck de HML - https://nibowebapp-hml.azurewebsites.net//TesteNibo/Healthcheck
                                        - Healthcheck de PRD - https://nibowebapp.azurewebsites.net//TesteNibo/Healthcheck
                                Recrusos Usados:
                                    Azure DevOps:
                                        - Build e Release
                                    Azure Cloud
                                        - Resouce Group chamado NiboWebApp
                                        - Web App
                                        - aplication insatis para monitoramento
 
     Build 2  - Nibo Web App Docker - esse fa um build roda os testes automatizados, cria uma imagem docker e publica essa imagem em uma Registry no Azure.
                                      Logo depois a Release e ativada fazendo o deploy da imagem do Registry no Web App configurado p rodar container em ambiente de HML.
                                     Se o Healthcheck passar em HML o pipeline faz o deploy em Produção.
                                URLs
                                    URL Index
                                        - HML - https://niboteste-hml.azurewebsites.net
                                        - PRD - https://niboteste.azurewebsites.net
                                    URL Healthcheck
                                        - Healthcheck de HML - https://niboteste-hml.azurewebsites.net/TesteNibo/Healthcheck
                                        - Healthcheck de PRD - https://niboteste.azurewebsites.net/TesteNibo/Healthcheck
                                Recrusos Usados:
                                    Azure DevOps:
                                        - Build e Release
                                    Azure Cloud
                                        - Resouce Group chamado Nibo
                                        - Web App for containers
                                        - Azure registry
OSB
    se precisarem de acesso a todos os links pode me retornar com um email que adiono na hora.

Pessoal, qualquer duvida estou a disposição para explicar melhor a ideia. inclusive sobre a parte de docker 
que não foi possivel fazer.
tel/WhatsApp:(31)98325-6463







