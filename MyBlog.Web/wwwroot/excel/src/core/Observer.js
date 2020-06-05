export class Observer {
  constructor() {
    this.listeners = {}
  }

  dispatch(event, ...args) {
    this.listeners[event].forEach(listener => {
      listener(...args)
    })
    return true
  }

  subscribe(event, fn) {
    this.listeners[event] = this.listeners[event] || []
    this.listeners[event].push(fn)
    return () => {
      this.listeners[event].filter(listener => listener !== fn)
    }
  }
}
