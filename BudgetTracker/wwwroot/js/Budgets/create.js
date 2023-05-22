$(document).ready(() => {
    const $periodicitySelect = $("#Periodicity")
    const $toDateWrapper = $("#ToDateWrapper")
    const $repeatsWrapper = $("#RepeatsWrapper")

    $periodicitySelect.change((elm) => {
        const value = $(elm.target).val()

        if (value === 'Custom') {
            $toDateWrapper.show()
            $repeatsWrapper.show()
        }
        else {
            $toDateWrapper.hide()
            $repeatsWrapper.hide()
        }
    })
})