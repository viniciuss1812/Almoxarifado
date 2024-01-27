const buttonClick = document.getElementById("btnGravar");

buttonClick.addEventListener("click", function(){
    console.log("Clicou em gravar");
    const objIDDep = document.getElementById("idDepartamento");
    const objNomeDep = document.getElementById("departamento");
    const objData = document.getElementById("dataRequisicao");
    const campos = document.querySelectorAll('[data-obrigatorio="true"]')
    let temCampoVazio = false;
    campos.forEach(function(itemElemento){
        console.log(itemElemento.value);
        if( itemElemento.value==""){
            itemElemento.style.backgroundColor="red";
        }else{
            itemElemento.style.backgroundColor="#ffffff"
        }
        return;
    })
    if(temCampoVazio){
        return;
    }
    console.log("final do gravar");

})


function adicionarCorFundoAoFocar(){
    const inputs = document.querySelectorAll('input,select');

    inputs.forEach(function(itemElemento){
        itemElemento.addEventListener('focus', function(){
            itemElemento.style.backgroundColor="green";
        });
        itemElemento.addEventListener('blur', function(){
            itemElemento.style.backgroundColor="#ffffff";
            itemElemento.style.color="#000000"
        })
    })
}

function adicionarCamposAceitarSomenteInteiro(){
    const campos = document.querySelectorAll('[data-soInteiroPositivo="true"]')
    campos.forEach(function(item){
        const teclasAceitas = [48,49,50,51,52,53,54,55,56,57,99,97,98,99,100,101,102,103,104,105]
        item.addEventListener('keyup',function(e){
           if(!teclasAceitas.includes(e.keyCode)){
                item.value="";
            } 
       })
    })
}

function carregarCategoria(){
    const elementCategoria = document.getElementById("categoriaMotivo");
    categorias.forEach(function (objCat){
        let opt = document.createElement('option');
        opt.text = objCat.Descricao;
        opt.value = objCat.idCategoria;
        elementCategoria.appendChild(opt);
    })
    // console.log(categorias);
    function carregarMotivoAoAlterarCategoria(){
        const elementCategoria = document.getElementById("categoriaMotivo");
        elementCategoria.addEventListener("change", function(){
            let valorEscolhido = elementCategoria.value;
            const motivosfiltrados = motivos.filter((obj) => obj.idCategoria==valorEscolhido)

            const elementMotivo = document.getElementById("Motivo");
            elementMotivo.innerHTML = "";
            motivosFiltrados.forEach(function(item)){
                let opt = document.createElement('option');
                opt.text = item.Descricao;
                opt.value = item.IdMotivo;
                elementMotivo.appendChild(opt);
            }

        })
    }
    function carregarNomeDepartamentoAoAlterarIDDep(){
        const elementIdDep = document.getElementById("idDepartamento");
        elementIdDep.addEventListener("keyup", fuction)
    }
}

carregarCategoria();
adicionarCorFundoAoFocar();
adicionarCamposAceitarSomenteInteiro();