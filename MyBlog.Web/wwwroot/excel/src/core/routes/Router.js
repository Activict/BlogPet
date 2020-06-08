import {$} from '@core/dom';

export class Router {
  constructor(selector, routes) {
    if (!selector) {
      throw new Error('Selector is not provided in Router')
    }

    this.$placeholder = $(selector)
    this.routes = routes
    this.page = null

    this.changePageHandler = this.changePageHandler.bind(this)

    this.init()
  }

  init() {
    window.addEventListener('hashchange', this.changePageHandler)
    this.changePageHandler()
  }

  changePageHandler() {
    if (this.page) {
      this.page.destroy()
    }
    const Page = this.activeRoutePath().includes('excel') ?
      this.routes.excel : this.routes.dashboard
    this.page = new Page(this.param())
    this.$placeholder.clear().append(this.page.getRoot())
    this.page.afterRender()
  }

  activeRoutePath() {
    return window.location.hash.slice(1)
  }

  param() {
    return this.activeRoutePath().split('/')[1]
  }

  destroy() {
    window.removeEventListener('hashchange', this.changePageHandler)
  }
}
