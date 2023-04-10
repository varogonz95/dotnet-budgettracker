$(document).ready(() => {
    console.log("Page ready")

    const $periodicitySelect = $("#Periodicity")
    const $toDateDiv = $("#ToDateDiv")

    $periodicitySelect.change((elm) => {
        const value = $(elm.target).val()

        if (value === 'Custom') {
            $toDateDiv.toggle()
        }
        else {
            $toDateDiv.hide()
        }
    })
})