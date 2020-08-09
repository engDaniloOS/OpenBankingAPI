var user = prompt("Ambiente produtivo. Digite 'Prod' para prosseguir");

if (user != "Prod") {
    window.stop();
    window.alert("Recarregue a página e tente novamente!");
}
