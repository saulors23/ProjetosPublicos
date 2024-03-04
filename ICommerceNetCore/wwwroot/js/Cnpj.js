function formatAndValidateCnpj(input) {
    // Remove caracteres não numéricos
    let cnpj = input.value.replace(/\D/g, '');

    // Formatar o CNPJ
    if (cnpj.length >= 2) {
        cnpj = cnpj.substring(0, 2) + '.' + cnpj.substring(2);
    }
    if (cnpj.length >= 6) {
        cnpj = cnpj.substring(0, 6) + '.' + cnpj.substring(6);
    }
    if (cnpj.length >= 10) {
        cnpj = cnpj.substring(0, 10) + '/' + cnpj.substring(10);
    }
    if (cnpj.length >= 15) {
        cnpj = cnpj.substring(0, 15) + '-' + cnpj.substring(15);
    }

    // Atualizar o valor do input com o CNPJ formatado
    input.value = cnpj;

    // Validar o CNPJ
    if (cnpj.length === 18) {
        if (isValidCnpj(cnpj)) {
            input.setCustomValidity(''); // CNPJ válido
        } else {
            input.setCustomValidity('CNPJ Incorreto!');
        }
    } else {
        input.setCustomValidity('Informe um CNPJ Correto!');
    }
}

function isValidCnpj(cnpj) {
    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj.length !== 14 || /^(\d)\1+$/.test(cnpj)) {
        return false;
    }

    let tamanho = cnpj.length - 2;
    let numeros = cnpj.substring(0, tamanho);
    let digitos = cnpj.substring(tamanho);
    let soma = 0;
    let pos = tamanho - 7;

    for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
    }

    let resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);

    if (resultado != digitos.charAt(0)) {
        return false;
    }

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;

    for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
    }

    resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);

    return resultado == digitos.charAt(1);
}