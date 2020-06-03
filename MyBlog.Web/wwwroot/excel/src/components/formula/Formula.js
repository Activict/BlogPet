import {ExcelComponent} from '@core/ExcelComponent';

export class Formula extends ExcelComponent {
  constructor($root) {
    super($root, {
      name: 'Formula',
      listeners: ['input', 'click'],
    })
  }

  nameClass() {
    return 'excel__formula'
  }

  toHTML() {
    return `
     <div class="info">fx</div>
     <div class="input" contenteditable spellcheck="false"></div>
`;
  }

  onInput(event) {
    console.log('Formula ', event)
  }

  onClick() {
    console.log('')
  }
}
