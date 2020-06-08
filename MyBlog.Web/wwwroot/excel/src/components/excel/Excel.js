import {$} from '@core/dom'
import {Observer} from '@core/Observer';
import {StoreSubscriber} from '@core/StoreSubscriber';
import {updateDate} from '@/redux/actions';

export class Excel {
  constructor(options) {
    this.components = options.components || []
    this.observer = new Observer()
    this.store = options.store
    this.subscriber = new StoreSubscriber(this.store)
  }

  getRoot() {
    const $root = $.create('div', 'excel')
    const componentOptions = {
      observer: this.observer,
      store: this.store,
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

  init() {
    this.store.dispatch(updateDate())
    this.subscriber.subscribeComponents(this.components)
    this.components.forEach(component => component.init())
  }

  destroy() {
    this.subscriber.unsubscribeFromStore()
    this.components.forEach(component => component.destroy())
  }
}
