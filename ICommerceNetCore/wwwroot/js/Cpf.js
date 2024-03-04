///////////////////////////////////////////////////////////////////////
// VALIDAÇÃO CPF /////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////

function formatarCPF(input) {
    // Remove caracteres não numéricos
    let cpf = input.value.replace(/\D/g, '');

    // Formatar o CPF
    if (cpf.length >= 3) {
        cpf = cpf.substring(0, 3) + '.' + cpf.substring(3);
    }
    if (cpf.length >= 7) {
        cpf = cpf.substring(0, 7) + '.' + cpf.substring(7);
    }
    if (cpf.length >= 11) {
        cpf = cpf.substring(0, 11) + '-' + cpf.substring(11);
    }

    // Atualizar o valor do input com o CPF formatado
    input.value = cpf;

    // Validar o CPF
    if (cpf.length === 14) {
        if (validarCPF(cpf)) {
            input.setCustomValidity(''); // CPF válido
        } else {
            input.setCustomValidity('CPF Incorreto!');
        }
    } else {
        input.setCustomValidity('Informe um CPF Correto!');
    }
}

function validarCPF(cpf) {
    // Validação do CPF
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf === '' || cpf.length !== 11) return false;

    // Verificação dos dígitos verificadores
    let add = 0;
    for (let i = 0; i < 9; i++) {
        add += parseInt(cpf.charAt(i)) * (10 - i);
    }
    let rev = 11 - (add % 11);
    if (rev === 10 || rev === 11) {
        rev = 0;
    }
    if (rev !== parseInt(cpf.charAt(9))) {
        return false;
    }

    add = 0;
    for (let i = 0; i < 10; i++) {
        add += parseInt(cpf.charAt(i)) * (11 - i);
    }
    rev = 11 - (add % 11);
    if (rev === 10 || rev === 11) {
        rev = 0;
    }
    if (rev !== parseInt(cpf.charAt(10))) {
        return false;
    }

    return true;
}
///////////////////////////////////////////////////////////////////////
// FINAL VALIDAÇÃO CPF ///////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////

