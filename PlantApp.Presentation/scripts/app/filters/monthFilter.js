angular.module('myApp').filter('convertMonth', function () {
    return function (ele) {

        var monthsInWords = "";
        var oneMonth = "";

        for (var i = 0; i < ele.length; i++) {

            if (i !== ',') {
                oneMonth += ele[i];
            }
            else {
                addMonth(oneMonth);
                i++;
                oneMonth = "";
            }
        }

        var addMonth = function (oneMonth) {
            if (oneMonth == 1)
                monthsInWords += "January";
            else if (oneMonth == 2)
                monthsInWords += "February";
            else if (oneMonth == 3)
                monthsInWords += "March";
            else if (oneMonth == 4)
                monthsInWords += "April";
            else if (oneMonth == 5)
                monthsInWords += "May";
            else if (oneMonth == 6)
                monthsInWords += "June";
            else if (oneMonth == 7)
                monthsInWords += "July";
            else if (oneMonth == 8)
                monthsInWords += "August";
            else if (oneMonth == 9)
                monthsInWords += "September";
            else if (oneMonth == 10)
                monthsInWords += "October";
            else if (oneMonth == 11)
                monthsInWords += "November";
            else if (oneMonth == 12)
                monthsInWords += "December";
        };

        return monthsInWords;


    };

});