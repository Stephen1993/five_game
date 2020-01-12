let instance = null
let ctx = null
let screenWidth = window.innerWidth // 屏幕宽度
let screenHeight = window.innerHeight // 屏幕高度

let chessSpace = 5
let chessNum = 12
let chessRadius = (screenWidth - chessNum * chessSpace) / chessNum / 2
let chessList = []
let mp = []
let gameState = 0
let chessState = 0
let chessColor = 0
let n = chessNum
let m = chessNum

export default class GameView {
	/**
	 * 
	 * @author chenyang
	 * 游戏主界面类
	 */

    constructor(_ctx) {
        if (instance) {
            return instance
        }

        instance = this
        ctx = _ctx
        this.initEvent()
        this.initChessPos()
        this.drawView()
    }

    initEvent() { // 初始化监听事件
        canvas.addEventListener('touchstart', this.touchFun.bind(this))
        // canvas.addEventListener('touchmove', this.touchFun.bind(this))
        // canvas.addEventListener('touchend', this.touchFun.bind(this))
    }

    touchFun(e) { // 触摸回调函数
        e.preventDefault()
        let event = e.touches[0]
        let x = event.clientX
        let y = event.clientY
        // 点击开始按钮
        if (Math.abs(screenWidth / 2 - x) <= 20 && Math.abs(chessNum * (chessRadius * 2 + chessSpace) * 1.5 - y) <= 20) {
            this.restartGame()
            return
        }

        if (gameState != 1 || chessState != chessColor) return

        // 画棋子
        if (x + 5 < chessList[0][0][0] || x - 5 > chessList[n - 1][m - 1][0]) {
            return
        }
        if (y + 5 < chessList[0][0][1] || y - 5 > chessList[n - 1][m - 1][1]) {
            return
        }
        let px = 0, py = 0, minDist = 1000000000;
        for (let i = 0; i < n; ++i) {
            for (let j = 0; j < m; ++j) {
                let tmpDist = Math.sqrt(Math.pow(chessList[i][j][0] - x, 2) + Math.pow(chessList[i][j][1] - y, 2))
                if (tmpDist < minDist) {
                    minDist = tmpDist
                    px = i
                    py = j
                }
            }
        }
        if (mp[px][py] != undefined) {
            return
        }
        this.downQi(px, py, chessColor)
        if (this.checkGameStatus(px, py, chessColor)) {
            this.gameWin("玩家胜利")
            return
        }
        this.computeDown()
    }

    initChessPos() {
        for (let i = 0; i < n; ++i) {
            mp.push([])
            chessList.push([])
            for (let j = 0; j < m; ++j) {
                mp[i][j] = undefined
                chessList[i][j] = undefined
            }
        }
        let x = chessRadius + chessSpace
        let y = (screenHeight - chessNum * (chessRadius * 2 + chessSpace)) / 2 + chessRadius + chessSpace
        let tmpx = x, tmpy = y;
        for (let i = 0; i < chessNum; ++i) {
            tmpy = y + (chessRadius * 2 + chessSpace) * i
            for (let j = 0; j < chessNum; ++j) {
                tmpx = x + (chessRadius * 2 + chessSpace) * j
                chessList[i][j] = [tmpx, tmpy]
            }
        }
    }

    drawView() {
        // 画背景
        ctx.fillStyle = "rgb(49, 102, 139)"
        ctx.fillRect(0, 0, screenWidth, screenHeight)

        // 画棋盘
        ctx.fillStyle = "rgb(203, 167, 138)"
        ctx.fillRect(0, (screenHeight - chessNum * (chessRadius * 2 + chessSpace)) / 2, screenWidth, chessNum * (chessRadius * 2 + chessSpace))

        // 画开始按钮
        ctx.beginPath();
        ctx.arc(screenWidth / 2, chessNum * (chessRadius * 2 + chessSpace) * 1.5, 30, 0, 2 * Math.PI);
        ctx.fillStyle = 'rgb(56, 206, 210)';
        ctx.shadowOffsetY = 2;
        ctx.shadowColor = 'rgba(0,0,0,0.54)';
        ctx.fill();
        ctx.fillStyle = 'white';
        ctx.textAlign = 'center';
        ctx.font = '20px sans-serif';
        ctx.shadowOffsetY = 1;
        ctx.fillText("开始", screenWidth / 2, chessNum * (chessRadius * 2 + chessSpace) * 1.5 + 5);

        // 画棋线
        let lastX1 = chessRadius + chessSpace
        let lastX2 = chessNum * (chessRadius * 2 + chessSpace) - chessRadius
        let lastY1 = (screenHeight - chessNum * (chessRadius * 2 + chessSpace)) / 2 + chessRadius + chessSpace
        let lastY2 = 0
        for (let i = 0; i < chessNum; ++i) {
            ctx.beginPath();
            ctx.strokeStyle = 'rgb(55, 42, 26)'; //设置字体透明度和颜色
            ctx.lineWidth = 1; //设置画笔的粗细
            ctx.moveTo(lastX1, lastY1);
            ctx.lineTo(lastX2, lastY1);
            ctx.stroke();
            lastY1 += chessRadius * 2 + chessSpace
        }

        lastY2 = lastY1 - chessRadius * 2 - chessSpace
        lastY1 = (screenHeight - chessNum * (chessRadius * 2 + chessSpace)) / 2 + chessRadius + chessSpace
        lastX1 = chessRadius + chessSpace
        for (let i = 0; i < chessNum; ++i) {
            ctx.beginPath();
            ctx.strokeStyle = 'rgb(55, 42, 26)'; //设置字体透明度和颜色
            ctx.lineWidth = 1; //设置画笔的粗细
            ctx.moveTo(lastX1, lastY1);
            ctx.lineTo(lastX1, lastY2);
            ctx.stroke();
            lastX1 += chessRadius * 2 + chessSpace
        }
    }

    downQi(x, y, color) {
        ctx.beginPath()
        ctx.arc(chessList[x][y][0], chessList[x][y][1], chessRadius, 0, 2 * Math.PI);
        if (color == 1) {
            ctx.fillStyle = 'black';
        } else {
            ctx.fillStyle = 'white';
        }
        ctx.fill();
        mp[x][y] = color
        chessState = color ^ 1
    }

    gameWin(title) {
        gameState = 0

        ctx.fillStyle = 'red';
        ctx.font = '28px sans-serif';
        ctx.textAlign = 'center';
        ctx.fillText(title, screenWidth / 2.0, screenHeight - 30);
    }

    restartGame() {
        gameState = 1
        chessState = chessState ^ 1
        chessColor = chessColor ^ 1
        mp = []
        this.initChessPos()
        this.drawView()
        ctx.fillStyle = 'rgb(56, 206, 210)';
        ctx.font = '16px sans-serif';
        ctx.textAlign = 'center';
        ctx.fillText("游戏进行中：" + (chessState == 1 ? "用户先手" : "电脑先手"), screenWidth / 2, (screenHeight - chessNum * (chessRadius * 2 + chessSpace)) / 2 - 20);
        if (chessState == 0) {
            this.computeDown()
        }
    }

    checkGameStatus(x, y, color) {
        if (mp[x][y] == undefined) return false;
        let i = 0, j = 0;
        let flag = color
        //横连
        for (i = y; i - 1 >= 0 && mp[x][i - 1] == flag; --i);
        for (j = y; j + 1 < m && mp[x][j + 1] == flag; ++j);
        if (j - i + 1 == 5) return true;

        //竖连
        for (i = x; i - 1 >= 0 && mp[i - 1][y] == flag; --i);
        for (j = x; j + 1 < n && mp[j + 1][y] == flag; ++j);
        if (j - i + 1 == 5) return true;

        //左斜
        for (i = 1; x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == flag; ++i);
        for (j = 1; x + j < n && y + j < m && mp[x + j][y + j] == flag; ++j);
        if (j + i - 1 == 5) return true;

        //右斜
        for (i = 1; x - i >= 0 && y + i < m && mp[x - i][y + i] == flag; ++i);
        for (j = 1; x + j < n && y - j >= 0 && mp[x + j][y - j] == flag; ++j);
        if (j + i - 1 == 5) return true;

        return false
    }

    computeDown() {
        if (gameState != 1) return;
        // 计算电脑
        let maxVal1 = -1
        let x1 = 0, y1 = 0
        for (let i = 0; i < n; ++i) {
            for (let j = 0; j < m; ++j) {
                if (mp[i][j] == undefined) {
                    let tmpVal = this.calVal(i, j, chessColor ^ 1)
                    if (tmpVal > maxVal1) {
                        maxVal1 = tmpVal
                        x1 = i
                        y1 = j
                    } else if (tmpVal == maxVal1 && Math.abs(n / 2 - x1) + Math.abs(m / 2 - y1) > Math.abs(n / 2 - i) + Math.abs(m / 2 - j)) {
                        x1 = i
                        y1 = j
                    }
                    if (maxVal1 == 1000000000) break
                }
            }
        }

        // 计算用户
        let maxVal2 = -1
        let x2 = 0, y2 = 0
        for (let i = 0; i < n; ++i) {
            for (let j = 0; j < m; ++j) {
                if (mp[i][j] == undefined) {
                    let tmpVal = this.calVal(i, j, chessColor)
                    if (tmpVal > maxVal2) {
                        maxVal2 = tmpVal
                        x2 = i
                        y2 = j
                    } else if (tmpVal == maxVal2 && Math.abs(n / 2 - x2) + Math.abs(m / 2 - y2) > Math.abs(n / 2 - i) + Math.abs(m / 2 - j)) {
                        x2 = i
                        y2 = j
                    }
                    if (maxVal2 == 1000000000) break
                }
            }
        }

        if (maxVal1 == 1000000000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal2 == 1000000000) this.downQi(x2, y2, chessColor ^ 1)
        else if (maxVal1 >= 10000000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal2 >= 10000000) this.downQi(x2, y2, chessColor ^ 1)
        else if (maxVal1 >= 1000000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal2 >= 1000000) this.downQi(x2, y2, chessColor ^ 1)
        else if (maxVal1 >= 100000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal2 >= 100000) this.downQi(x2, y2, chessColor ^ 1)
        else if (maxVal1 >= 10000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal2 >= 10000) this.downQi(x2, y2, chessColor ^ 1)
        else if (maxVal1 >= 1000) this.downQi(x1, y1, chessColor ^ 1)
        else if (maxVal1 >= maxVal2) this.downQi(x1, y1, chessColor ^ 1)
        else this.downQi(x2, y2, chessColor ^ 1)

        if (this.checkGameStatus(x1, y1, chessColor ^ 1)) {
            this.gameWin("电脑胜利")
        }
    }

    //计算每个位置的权值
    calVal(x, y, color) {
        let i = 0, j = 0;
        let flag = color
        let numfour = 0, numthree = 0, numtwo = 0, tempval = 0;
        //横连
        for (i = y; i - 1 >= 0 && mp[x][i - 1] == flag; --i);
        for (j = y; j + 1 < m && mp[x][j + 1] == flag; ++j);
        if (j - i + 1 == 5) return 1000000000;
        else if (j - i + 1 == 4) {
            if (i - 1 >= 0 && mp[x][i - 1] == undefined)++numfour;
            if (j + 1 < m && mp[x][j + 1] == undefined)++numfour;
        }
        else if (j - i + 1 == 3) {
            if (i - 1 >= 0 && mp[x][i - 1] == undefined && i - 2 >= 0 && mp[x][i - 2] == undefined)++numthree;
            if (i - 1 >= 0 && mp[x][i - 1] == undefined && j + 1 < m && mp[x][j + 1] == undefined)++numthree;
            if (j + 1 < m && mp[x][j + 1] == undefined && j + 2 < m && mp[x][j + 2] == undefined)++numthree;
            if (j + 1 < m && mp[x][j + 1] == undefined && i - 1 >= 0 && mp[x][i - 1] == undefined)++numthree;
        }
        else if (j - i + 1 == 2) {
            let a = 1, b = 1;
            while (i - a >= 0 && mp[x][i - a] == undefined)++a;
            while (j + b < m && mp[x][j + b] == undefined)++b;
            if (a + b - 2 >= 3 && i - 1 >= 0 && mp[x][i - 1] == undefined)++numtwo;
            if (a + b - 2 >= 3 && j + 1 < m && mp[x][j + 1] == undefined)++numtwo;
        }

        //竖连
        for (i = x; i - 1 >= 0 && mp[i - 1][y] == flag; --i);
        for (j = x; j + 1 < n && mp[j + 1][y] == flag; ++j);
        if (j - i + 1 == 5) return 1000000000;
        else if (j - i + 1 == 4) {
            if (i - 1 >= 0 && mp[i - 1][y] == undefined)++numfour;
            if (j + 1 < n && mp[j + 1][y] == undefined)++numfour;
        }
        else if (j - i + 1 == 3) {
            if (i - 1 >= 0 && mp[i - 1][y] == undefined && i - 2 >= 0 && mp[i - 2][y] == undefined)++numthree;
            if (i - 1 >= 0 && mp[i - 1][y] == undefined && j + 1 < n && mp[j + 1][y] == undefined)++numthree;
            if (j + 1 < n && mp[j + 1][y] == undefined && j + 2 < n && mp[j + 2][y] == undefined)++numthree;
            if (j + 1 < n && mp[j + 1][y] == undefined && i - 1 >= 0 && mp[i - 1][y] == undefined)++numthree;
        }
        else if (j - i + 1 == 2) {
            let a = 1, b = 1;
            while (i - a >= 0 && mp[i - a][y] == undefined)++a;
            while (j + b < n && mp[j + b][y] == undefined)++b;
            if (a + b - 2 >= 3 && i - 1 >= 0 && mp[i - 1][y] == undefined)++numtwo;
            if (a + b - 2 >= 3 && j + 1 < n && mp[j + 1][y] == undefined)++numtwo;
        }

        //左斜
        for (i = 1; x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == flag; ++i);
        for (j = 1; x + j < n && y + j < m && mp[x + j][y + j] == flag; ++j);
        if (j + i - 1 == 5) return 1000000000;
        else if (j + i - 1 == 4) {
            if (x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == undefined)++numfour;
            if (x + j < n && y + j < m && mp[x + j][y + j] == undefined)++numfour;
        }
        else if (j + i - 1 == 3) {
            if (x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == undefined && x - i - 1 >= 0 && y - i - 1 >= 0 && mp[x - i - 1][y - i - 1] == undefined)++numthree;
            if (x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == undefined && x + j < n && y + j < m && mp[x + j][y + j] == undefined)++numthree;
            if (x + j < n && y + j < m && mp[x + j][y + j] == undefined && x + j + 1 < n && y + j + 1 < m && mp[x + j + 1][y + j + 1] == undefined)++numthree;
            if (x + j < n && y + j < m && mp[x + j][y + j] == undefined && x - i >= 0 && y - i >= 0 && mp[x - i][y - i] == undefined)++numthree;
        }
        else if (j + i - 1 == 2) {
            let a = i, b = j;
            while (x - i >= 0 && y - i >= 0 && mp[x - i, y - i] == undefined)++i;
            while (x + j < n && y + j < m && mp[x + j][y + j] == undefined)++j;
            if (j + i - 1 >= 5 && x - a >= 0 && y - a >= 0 && mp[x - a][y - a] == undefined)++numtwo;
            if (j + i - 1 >= 5 && x + b < n && y + b < m && mp[x + b][y + b] == undefined)++numtwo;
        }

        //右斜
        for (i = 1; x - i >= 0 && y + i < m && mp[x - i][y + i] == flag; ++i);
        for (j = 1; x + j < n && y - j >= 0 && mp[x + j][y - j] == flag; ++j);
        if (j + i - 1 == 5) return 1000000000;
        else if (j + i - 1 == 4) {
            if (x - i >= 0 && y + i < m && mp[x - i][y + i] == undefined)++numfour;
            if (x + j < n && y - j >= 0 && mp[x + j][y - j] == undefined)++numfour;
        }
        else if (j + i - 1 == 3) {
            if (x - i >= 0 && y + i < m && mp[x - i][y + i] == undefined && x - i - 1 >= 0 && y + i + 1 < m && mp[x - i - 1][y + i + 1] == undefined)++numthree;
            if (x - i >= 0 && y + i < m && mp[x - i][y + i] == undefined && x + j < n && y - j >= 0 && mp[x + j][y - j] == undefined)++numthree;
            if (x + j < n && y - j >= 0 && mp[x + j][y - j] == undefined && x + j + 1 < n && y - j - 1 >= 0 && mp[x + j + 1][y - j - 1] == undefined)++numthree;
            if (x + j < n && y - j >= 0 && mp[x + j][y - j] == undefined && x - i >= 0 && y + i < m && mp[x - i][y + i] == undefined)++numthree;
        }
        else if (j + i - 1 == 2) {
            let a = i, b = j;
            while (x - i >= 0 && y + i < m && mp[x - i][y + i] == undefined)++i;
            while (x + j < n && y - j >= 0 && mp[x + j][y - j] == undefined)++j;
            if (j + i - 1 >= 5 && x - a >= 0 && y + a < m && mp[x - a][y + a] == undefined)++numtwo;
            if (j + i - 1 >= 5 && x + b < n && y - b >= 0 && mp[x + b][y - b] == undefined)++numtwo;
        }
        if (numfour >= 2 || (numfour >= 1 && numthree >= 3)) tempval = 10000000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活4
        else if (numfour > 0 && color == (chessColor ^ 1)) tempval = 1000000 + numtwo * 10 + numthree * 100 + numfour * 1000;//连4
        else if (numthree >= 6 && color == chessColor) tempval = 1000000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活3
        else if (numfour > 0) tempval = 100000 + numtwo * 10 + numthree * 100 + numfour * 1000;//连4
        else if (numthree >= 6) tempval = 100000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活3
        else if (numthree >= 3) tempval = 10000 + numtwo * 10 + numthree * 100 + numfour * 1000;//可能的活连3
        else if (numtwo >= 6) tempval = 1000 + numtwo * 10 + numthree * 100 + numfour * 1000;//活2
        else if (numthree > 0) tempval = 100 + numtwo * 10 + numthree * 100 + numfour * 1000;//连3
        else if (numtwo > 0) tempval = 10 + numtwo * 10 + numthree * 100 + numfour * 1000;
        else tempval = 1;
        return tempval;
    }
}