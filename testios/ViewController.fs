namespace test2

open System

open Foundation
open UIKit
open System.Linq
open UIKit

[<Register ("ViewController")>]
type ViewController (handle:IntPtr) =
    inherit UIViewController (handle)

    override x.DidReceiveMemoryWarning () =
        // Releases the view if it doesn't have a superview.
        base.DidReceiveMemoryWarning ()
        // Release any cached data, images, etc that aren't in use.

    override x.ViewDidLoad () =
        base.ViewDidLoad ()
        let label = x.View.Subviews.FirstOrDefault(fun v -> v.AccessibilityIdentifier = "TotoLabel") :?> UILabel
        let button = x.View.Subviews.FirstOrDefault(fun v -> v.AccessibilityIdentifier = "TotoButton") :?> UIButton
        button.TouchUpInside.Add (fun e -> label.Text <- "Clicked")
        // Perform any additional setup after loading the view, typically from a nib.

    override x.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation) =
        // Return true for supported orientations
        if UIDevice.CurrentDevice.UserInterfaceIdiom = UIUserInterfaceIdiom.Phone then
           toInterfaceOrientation <> UIInterfaceOrientation.PortraitUpsideDown
        else
           true
