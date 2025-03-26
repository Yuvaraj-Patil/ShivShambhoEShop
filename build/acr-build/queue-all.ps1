Param(
    [parameter(Mandatory=$false)][string]$acrName,
    [parameter(Mandatory=$false)][string]$gitUser,
    [parameter(Mandatory=$false)][string]$repoName="ShivShambho_eShopOnContainers",
    [parameter(Mandatory=$false)][string]$gitBranch="dev",
    [parameter(Mandatory=$true)][string]$patToken
)

$gitContext = "https://github.com/$gitUser/$repoName"

$services = @( 
    @{ Name="ShivShambho_eShopbasket"; Image="ShivShambho_eShop/basket.api"; File="src/Services/Basket/Basket.API/Dockerfile" },
    @{ Name="ShivShambho_eShopcatalog"; Image="ShivShambho_eShop/catalog.api"; File="src/Services/Catalog/Catalog.API/Dockerfile" },
    @{ Name="ShivShambho_eShopidentity"; Image="ShivShambho_eShop/identity.api"; File="src/Services/Identity/Identity.API/Dockerfile" },
    @{ Name="ShivShambho_eShopordering"; Image="ShivShambho_eShop/ordering.api"; File="src/Services/Ordering/Ordering.API/Dockerfile" },
	@{ Name="ShivShambho_eShoporderingbg"; Image="ShivShambho_eShop/orderprocessor"; File="src/Services/Ordering/OrderProcessor/Dockerfile" },
    @{ Name="ShivShambho_eShopwebspa"; Image="ShivShambho_eShop/webspa"; File="src/Web/WebSPA/Dockerfile" },
    @{ Name="ShivShambho_eShopwebmvc"; Image="ShivShambho_eShop/webmvc"; File="src/Web/WebMVC/Dockerfile" },
    @{ Name="ShivShambho_eShopwebstatus"; Image="ShivShambho_eShop/webstatus"; File="src/Web/WebStatus/Dockerfile" },
    @{ Name="ShivShambho_eShoppayment"; Image="ShivShambho_eShop/paymentprocessor"; File="src/Services/Payment/PaymentProcessor/Dockerfile" },
    @{ Name="ShivShambho_eShopocelotapigw"; Image="ShivShambho_eShop/ocelotapigw"; File="src/ApiGateways/ApiGw-Base/Dockerfile" },
    @{ Name="ShivShambho_eShopmobilShivShambho_eShoppingagg"; Image="ShivShambho_eShop/mobilShivShambho_eShoppingagg"; File="src/ApiGateways/Mobile.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="ShivShambho_eShopwebshoppingagg"; Image="ShivShambho_eShop/webshoppingagg"; File="src/ApiGateways/Web.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="ShivShambho_eShoporderingsignalrhub"; Image="ShivShambho_eShop/ordering.signalrhub"; File="src/Services/Ordering/Ordering.SignalrHub/Dockerfile" }
)

$services |% {
    $bname = $_.Name
    $bimg = $_.Image
    $bfile = $_.File
    Write-Host "Setting ACR build $bname ($bimg)"    
    az acr build-task create --registry $acrName --name $bname --image ${bimg}:$gitBranch --context $gitContext --branch $gitBranch --git-access-token $patToken --file $bfile
}
