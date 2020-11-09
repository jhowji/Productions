var canvas = document.querySelector("#jogo");
var ctx = canvas.getContext("2d");
var botao = document.querySelector("#btn");
var botao2 = document.querySelector("#btn2");
var pontos = 10;
//IMAGENS
var img = new Image();
img.src = "inimigo.gif";
img.name = "disco";

var universo = new Image;
universo.src = "universo.png"

//AUDIO
var musica = new Audio();
musica.src = "fundo.mp3";
botao.addEventListener("click", function(e) {  
        musica.play();
        musica.volume = 0.3;
})
botao2.addEventListener("click", function(e) {  
    musica.pause();
})
var som = new Audio();
som.src = "correct.mp3";

var som2 = new Audio();
som2.src = "wrong.Mp3";

var direcao = Math.round(Math.random()*3)+1;
var inimigo = {
    skin: img,
    x: Math.round(Math.random()*250),
    y: -100
}
var pos_coord = {
    x:0,
    y:0
}
tam = Math.round(Math.random()*100)+10;
var tempo = 100;



//MECANICA
function update(){
    
    ctx.drawImage(universo,0,0);
    ctx.drawImage(objcorrente.skin,objcorrente.x,objcorrente.y,tam,tam);
    inimigo.y += 10;
    ctx.font="18px arial";
    ctx.fillStyle = "white";
    ctx.fillText("Pontos: "+pontos,200,50);
    
}

//ANIMAÇÃO 
function draw(){
    objcorrente = inimigo;
    ctx.clearRect(0,0,canvas.width,canvas.height);
    ctx.drawImage(objcorrente.skin,objcorrente.x,objcorrente.y,tam,tam);
    update();
    if (objcorrente.y > canvas.height){
        inimigo.x = Math.round(Math.random()*250);
        inimigo.y = -100;
        tam = Math.round(Math.random()*100)+10;
        }
    var game = setTimeout(draw, tempo);
}


//HITBOX
canvas.addEventListener("click", function(e) {
    if(e.pageX >= img.x
        && e.pageX <= img.x + 160
        && e.pageY >= img.y
        && e.pageY <= img.y + 70){
            hitbox()
        }
    else{
        som2.play;
        pontos--;
    }
    
})


 function hitbox (inimigo){
        img.x = 500 * (canvas.width - 350);
        img.y = 500 * (canvas.height - 350);
        som.play();
        pontos++ ;
}
var game = setTimeout(draw, tempo);