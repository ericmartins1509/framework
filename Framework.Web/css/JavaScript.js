////pessoa.master
//function SelecionarLinhaEndereco(linha) {
//    PageMethods.SelecionarLinhaEndereco2(linha);
//    $('#endereco-modal').modal('show');
//}

//pesquisa.master
function btnSelecionarLinha_Click(identificador) {
    window.parent.document.getElementById("txtIdentificador").value = identificador;
    window.parent.document.getElementById("txtIdentificador").onchange();
    window.parent.document.getElementById("btnFecharPesquisa").click();
}

//menu.master
var tabs = $('#tabs').bootstrapDynamicTabs().addTab({
    title: 'Home',
    //text: '',
    html: '<iframe src="../../home.aspx" FrameBorder="0" width="100%" onload="resizeIframe(this)"/>',
    closable: false
});

function addTab(title, url) {
    var tabs = $('#tabs').bootstrapDynamicTabs();
    tabs.addTab({
        title: title,
        html: '<iframe src="' + url + '" FrameBorder="0" width="100%" onload="resizeIframe(this)"/>'
    })
}

function resizeIframe(obj) {
    valor = ((obj.contentWindow.document.body.scrollHeight / 100) * 60);
    if (valor < 500) {
        valor = 500
    }
    if (valor > 600) {
        valor = 600
    }
    obj.style.height = valor + 'px';
}