//////////////////////////////////////////////////////////////////////////////////
// RECURSO DA API de consulta de CEP com o ViaCEP (https://viacep.com.br/) //////
////////////////////////////////////////////////////////////////////////////////

function consultarCEP() {
    const cep = document.getElementById('Cep').value;

    if (cep.length === 8) {
        $.ajax({
            url: `https://viacep.com.br/ws/${cep}/json/`,
            dataType: 'json',
            success: function (data) {
                if (!data.erro) {
                    document.getElementById('Endereco').value = data.logradouro;
                    document.getElementById('Bairro').value = data.bairro;
                    document.getElementById('Cidade').value = data.localidade;
                    document.getElementById('Uf').value = data.uf;
                } else {
                    exibirModal('CEP desconhecido!');
                }
            },
            error: function () {
                exibirModal('Erro na consulta do CEP!');
            }
        });
    }
}

function exibirModal(mensagem) {
    const modalMensagem = document.getElementById('modalMensagem');
    modalMensagem.textContent = mensagem;
    $('#meuModal').modal('show');

    // Fechar o modal após 3 segundos (3000 ms)
    setTimeout(fecharModal, 3000);
}

function fecharModal() {
    $('#meuModal').modal('hide');
}

const cepInput = document.getElementById('Cep');

cepInput.addEventListener('input', function (event) {
    const sanitizedValue = event.target.value.replace(/\D/g, ''); // Remove caracteres não numéricos
    event.target.value = sanitizedValue; // Atualiza o valor do campo
    consultarCEP();
});

cepInput.addEventListener('keydown', function (event) {
    if (event.key === 'Tab') {
        consultarCEP();
    }
});

cepInput.addEventListener('keypress', function (event) {
    const key = event.key;
    if (key < '0' || key > '9') {
        event.preventDefault();
    }
});    

///////////////////////////////////////////////////////////////////////////////////////////
// FINAL DO RECURSO DA API de consulta de CEP com o ViaCEP (https://viacep.com.br/) //////
/////////////////////////////////////////////////////////////////////////////////////////