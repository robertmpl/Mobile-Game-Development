
#import <UIKit/UIKit.h>

extern "C"
{
    void _HapticImpact(int style)
    {
        UIImpactFeedbackStyle feedbackStyle;

        switch (style)
        {
            case 0:
                feedbackStyle = UIImpactFeedbackStyleLight;
                break;
            case 1:
                feedbackStyle = UIImpactFeedbackStyleMedium;
                break;
            case 2:
                feedbackStyle = UIImpactFeedbackStyleHeavy;
                break;
            default:
                feedbackStyle = UIImpactFeedbackStyleLight;
                break;
        }

        UIImpactFeedbackGenerator *generator =
            [[UIImpactFeedbackGenerator alloc] initWithStyle:feedbackStyle];

        [generator impactOccurred];
    }
}
