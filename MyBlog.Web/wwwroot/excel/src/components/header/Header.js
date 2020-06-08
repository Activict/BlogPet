import {ExcelComponent} from '@core/ExcelComponent';
import {changeTitle} from '@/redux/actions';
import {defaultTitle} from '@/constants';
import {$} from '@core/dom';
import {debounce} from '@core/utils';

export class Header extends ExcelComponent {
  constructor($root, options) {
    super($root, {
      name: 'Header',
      listeners: ['input', 'click'],
      ...options,
    })
  }

  nameClass() {
    return 'excel__header'
  }

  prepare() {
    this.onInput = debounce(this.onInput, 300)
  }

  toHTML() {
    const title = this.store.getState().title || defaultTitle
    return `
        <input type="text" class="input" value="${title}"/>

        <div>
            <div class="button" data-button="remove">
                <i class="material-icons" data-button="remove">delete</i>
            </div>
            <div class="button" data-button="exit">
                <i class="material-icons" data-button="exit">exit_to_app</i>
            </div>
        </div>`;
  }

  onInput(event) {
    const $target = $(event.target)
    this.$dispatchStore(changeTitle($target.text()))
  }

  onClick(event) {
    const $target = $(event.target)

    if ($target.data.button === 'remove') {
      const decision = confirm('Вы действительно хотите удалить эту таблицу?')
      if (decision) {
        localStorage.removeItem('excel:' + window.location.hash.split('/')[1])
        window.location.hash = ''
      }
    } else if ($target.data.button === 'exit') {
      window.location.hash = ''
    }
  }
}
