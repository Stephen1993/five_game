import GameView from './gameview';

let ctx = canvas.getContext('2d');

/**
 * 游戏主函数
 */
export default class Main {
  constructor() {
    this.gameview = new GameView(ctx);
  }
}
