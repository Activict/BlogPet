export class TableSelection {
  constructor() {
    this.group = []
    this.current = null
  }

  // $el instanceof DOM === true
  select($el) {
    this.clearSelected()
    $el.focus().addClass('selected')
    this.group.push($el)
    this.current = $el
  }

  clearSelected() {
    this.group.forEach($el => $el.removeClass('selected'))
    this.group = []
  }

  selectGroup($group = []) {
    this.clearSelected()
    this.group = $group
    this.group.forEach($el => $el.addClass('selected'))
  }
}
