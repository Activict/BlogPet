import {$} from '@core/dom'
import {Observer} from '@core/Observer';

export class Excel {
  constructor(selector, options) {
    this.$el = $(selector)
    this.components = options.components || []
    this.observer = new Observer()
  }

  getRoot() {
    const $root = $.create('div', 'excel')
    const componentOptions = {
      observer: this.observer,
    }

    this.components = this.components.map(Component => {
      const $el = $.create('div')
      const component = new Component($el, componentOptions)
      $el.$el.classList.add(component.nameClass())
      $el.html(component.toHTML())
      $root.append($el)
      return component
    })
    return $root
  }

  render() {
    this.$el.append(this.getRoot())
    this.components.forEach(component => component.init())
  }

  destroy() {
    this.components.forEach(component => component.destroy())
  }
}
