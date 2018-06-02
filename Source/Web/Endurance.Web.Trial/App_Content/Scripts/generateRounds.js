$(window).ready(function () {
    $('#add').on('click', function() {
        var $rounds = $('.round-container');
        var newElemIndex = $rounds.length;
        var $elemCopy = $rounds.first().clone();

        populateNewElement($elemCopy, newElemIndex);

        $('#round-details-container').append($elemCopy);
    });

    $('#remove').on('click', function() {
        var $rounds = $('.round-container');
        var numberOfRounds = $rounds.length;

        if (numberOfRounds > 1) {
            $rounds.last().remove();
        }
    })

});

function populateNewElement($elem, index) {
    var firstId = 'round-' + index + '-length';
    var secondId = 'round-' + index + '-rest';

    $elem
        .find('.round-heading')
        .text('Round ' + (index + 1));

    $elem
        .find('label')
        .first()
        .attr('for', firstId);

    $elem
        .find('label')
        .eq(1)
        .attr('for', secondId);

    $elem
        .find('input')
        .first()
        .attr('id', firstId)
        .attr('name', 'Rounds[' + index + '].LengthInKilometers');

    $elem
        .find('input')
        .eq(1)
        .attr('id', secondId)
        .attr('name', 'Rounds[' + index + '].MaxRestTimeInMinutes');
}