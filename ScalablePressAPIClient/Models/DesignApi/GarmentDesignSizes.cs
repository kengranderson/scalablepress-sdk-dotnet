using System;
using System.Collections.Generic;
using System.Text;

namespace ScalablePress.API.Models.DesignApi
{
    /*

    GARMENT DESIGN CLASSIFICATIONS
    Garment design sizes are classified into four different categories.

    Category	Size	Description
    standard	14' x 16'	Adult sized garments
    pocket	10' x 10' (including height offset)	Adult sized garments with pockets, i.e. hoodies
    small	10' x 12'	Ladies' and youth sized garments
    youth-pocket	10' x 6' (including height offset)	Youth sized garments with pockets, i.e. hoodies

    */

    public enum GarmentDesignSizes
    {
        standard,
        pocket,
        small,

        //[Display("youth-pocket")]
        youth_pocket
    }
}

/*
Design API
The Design API takes in information about your print design (dimensions, files, position, etc.) and provides you with a designId which can be used to place an order.

Create design object
Retrieve design object
Delete design
Designs cannot be modified once created.

Authentication headers are required.
Create design object
DEFINITION

POST https://api.scalablepress.com/v2/design
EXAMPLE REQUEST

curl "https://api.scalablepress.com/v2/design" \
  -u ":YOURAPIKEY" \
  -F "type=screenprint" \
  -F "sides[front][artwork]=@image.eps" \
  -F "sides[front][colors][0]=white" \
  -F "sides[front][dimensions][width]=5" \
  -F "sides[front][position][horizontal]=C" \
  -F "sides[front][position][offset][top]=2.5" \
  -F "customization[0][id]=customization-id"
EXAMPLE RESPONSE

{
  "mode": "test",
  "type": "screenprint",
  "createdAt": "2014-03-15T16:59:19.596Z",
  "validation": {
    "result": null,
    "status": "finished"
  },
  "sides": {
    "front": {
      "artwork": "http://scalablepress.com/exampleimage.eps",
      "resize": true,
      "aspect": 1.008371385083714,
      "dimensions": {
        "width": 5
      },
      "position": {
        "horizontal": "C",
        "offset": {
          "top": 2.5
        }
      },
      "colors": [
        "white"
      ]
    }
  },
  "designId": "53ee3c6781cc09072c6af341"
}
Provide the details on your design in order to receive a designId, which is required to place an order.

ARGUMENTS
Design object

DESIGN OBJECT
Attribute	Type	Description


RESIZE
EXAMPLE REQUEST

curl "https://api.scalablepress.com/v2/design" \
  -u ":YOURAPIKEY" \
  -F "type=screenprint" \
  -F "sides[front][artwork]=@image.eps" \
  -F "sides[front][colors][0]=white" \
  -F "sides[front][dimensions][width]=5" \
  -F "sides[front][position][horizontal]=C" \
  -F "sides[front][position][offset][top]=2.5" \
  -F "sides[front][resize]=true"


     */
