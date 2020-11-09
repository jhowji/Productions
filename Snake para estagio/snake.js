var cvs = document.querySelector("#snake");
var ctx = cvs.getContext("2d");
var box = 20;
var img = new Image();
var img1 = new Image();
var snake = [];
snake[0] = {
    x: 10 * box,
    y: 10 * box
}
var começa = true;

var pontos = 0;

///PONTOS
var food = {
    x: Math.floor(Math.random() * 29 + 1) * box,
    y: Math.floor(Math.random() * 29 + 1) * box
}

var food1 = {
        x: Math.floor(Math.random() * 29 + 1) * box,
        y: Math.floor(Math.random() * 29 + 1) * box
    }
    ///TECLAS
var d;

document.addEventListener("keydown", direcao);

function direcao(event) {
    var key = event.keyCode
    if (key == 37 && d != "RIGHT") {
        d = "LEFT";
    } else if (key == 38 && d != "DOWN") {
        d = "UP";
    } else if (key == 39 && d != "LEFT") {
        d = "RIGHT";
    } else if (key == 40 && d != "UP") {
        d = "DOWN";
    }
}


function collision(head, array) {
    for (var i = 0; i < snake.length; i++) {
        if (head.x == array[i].x && head.y == array[i].y) {
            return true;
        }
    }
    return false;
}

var ratazana = setInterval(myColor, 8000)

function myrat() {
    img1.src = "IMG/rato.png";
    ctx.fillStyle = "black";
    ctx.drawImage(img1, food.x, food.y, 20, 20);
    clearInterval(myrat);

    var pare = setInterval(stoprat, 5000);

    function stoprat() {
        img1.src = "IMG/rato.png";
        ctx.fillStyle = "black";
        ctx.drawImage(img1, food.x, food.y, 20, 20);
        clearInterval(pare);
    }
}

var color = setInterval(myColor, 20000);

function myColor() {
    ctx.fillStyle = "white";
    ctx.fillRect(0, 20, cvs.width, cvs.height);
    clearInterval(myColor);

    var stop = setInterval(stopColor, 2000)

    function stopColor() {
        ctx.fillStyle = "black";
        ctx.fillRect(0, 20, cvs.width, cvs.height);
        clearInterval(stop);
    }
}


///ANIMAÇÃO , IMAGENS
function draw() {
    ctx.fillStyle = "black";
    ctx.fillRect(0, 0, cvs.width, 20);
    ctx.font = "20px Verdana";
    ctx.fillStyle = "white";
    ctx.fillText(pontos, cvs.width / 2, 20);


    ctx.fillStyle = "white";
    ctx.fillRect(0, 20, cvs.width, cvs.height)

    ctx.fillStyle = "white";
    ctx.fillRect(0, 20, cvs.width, cvs.height)

    for (var i = 0; i < snake.length; i++) {
        ctx.fillStyle = (i == 0) ? "green" : "blue";
        ctx.fillRect(snake[i].x, snake[i].y, box, box);
        ctx.strokeStyle = "red";
        ctx.strokeRect(snake[i].x, snake[i].y, box, box);
    }

    img.src = "IMG/cereja.png";
    ctx.fillStyle = "black";
    ctx.drawImage(img, food.x, food.y, 20, 20);



    ///MECANICAS
    var snakeX = snake[0].x;
    var snakeY = snake[0].y;

    if (d == "LEFT") snakeX -= box;
    if (d == "UP") snakeY -= box;
    if (d == "RIGHT") snakeX += box;
    if (d == "DOWN") snakeY += box;

    if (snakeX == food.x && snakeY == food.y) {
        food = {
            x: Math.floor(Math.random() * 29 + 1) * box,
            y: Math.floor(Math.random() * 29 + 1) * box
        }
        pontos++
    } else {
        snake.pop();
    }
    if (snakeX == food1.x && snakeY == food1.y) {
        food1 = {
            x: Math.floor(Math.random() * 29 + 1) * box,
            y: Math.floor(Math.random() * 29 + 1) * box
        }
        pontos++, pontos++, pontos++, pontos++, pontos++
    }

    var newHead = {
            x: snakeX,
            y: snakeY
        }
        ///GAME OVER ANDA AUTO F5 em 3 SEG
    if (snakeX < 0 || snakeX > cvs.width - box ||
        snakeY < 10 || snakeY > cvs.height - box ||
        collision(newHead, snake)) {
        clearInterval(game);
        setInterval(function() { prompt() }, 1000);
        if (prompt = true)
            setInterval(function() { window.location.reload(true); }, 3000);
    }
    snake.unshift(newHead);
}






var game = setInterval(draw, 100)
