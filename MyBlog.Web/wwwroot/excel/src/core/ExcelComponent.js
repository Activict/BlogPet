import {DomListener} from '@core/DomListener';

export class ExcelComponent extends DomListener {
  constructor($root, options = {}) {
    super($root, options.listeners)
    this.name = options.name || ''
    this.observer = options.observer
    this.unsubscribers = []

    this.prepare()
  }

  prepare() {
  }

  nameClass() {
    return '';
  }

  toHTML() {
    return '';
  }

  $dispatch(event, ...args) {
    this.observer.dispatch(event, ...args)
  }

  $on(event, fn) {
    const unsub = this.observer.subscribe(event, fn)
    this.unsubscribers.push(unsub)
  }

  init() {
    this.initDOMListeners()
  }

  destroy() {
    this.removeDOMListeners()
    this.unsubscribers.forEach(unsub => unsub())
  }
}
