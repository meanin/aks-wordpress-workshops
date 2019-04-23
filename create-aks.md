#Tworzenie klastra AKS

## Logowanie z Azure CLI
az login
## Tworzenie Resource Groupy
az group create --name wordpress-demo --location westeurope
## Tworzenie samego klastra
az aks create --resource-group wordpress-demo --name wordpresscluster --node-count 3 --node-vm-size Standard_B2s --location westeurope --generate-ssh-keys
## Pobranie poświadczeń
az aks get-credentials --resource-group wordpress-demo --name wordpresscluster