function toButton(button) {
  const dataAttr = `
    data-type="button"
    data-value='${JSON.stringify(button.value)}'
  `
  return `
        <div 
            class="button ${button.active ? 'active' : ''}"
            ${dataAttr}
        >
            <i 
              class="material-icons"
              ${dataAttr}
            >${button.icon}</i>      
        </div>
        `
}

export function createToolbar(state) {
  const buttons = [
    {
      icon: 'format_align_left',
      value: {textAlign: 'left'},
      active: state['textAlign'] === 'left',
    },
    {
      icon: 'format_align_center',
      value: {textAlign: 'center'},
      active: state['textAlign'] === 'center',
    },
    {
      icon: 'format_align_right',
      value: {textAlign: 'right'},
      active: state['textAlign'] === 'right',
    },
    {
      icon: 'format_bold',
      active: state['fontWeight'] === 'bold',
      value: {fontWeight: state['fontWeight'] === 'bold' ? 'normal' : 'bold'},
    },
    {
      icon: 'format_italic',
      active: state['fontStyle'] === 'italic',
      value: {fontStyle: state['fontStyle'] === 'italic' ? 'normal' : 'italic'},
    },
    {
      icon: 'format_underlined',
      active: state['textDecoration'] === 'underline',
      value: {textDecoration:
          state['textDecoration'] === 'underline' ? 'none' : 'underline'},
    },
  ]
  return buttons.map(toButton).join('')
}
