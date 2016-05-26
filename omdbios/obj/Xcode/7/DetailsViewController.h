// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface DetailsViewController : UIViewController {
	NSLayoutConstraint *__constraintlblGenreHeight;
	UIButton *_btnBack;
	NSLayoutConstraint *_constraintLblActorsHeight;
	NSLayoutConstraint *_constraintLblDirectorsHeight;
	NSLayoutConstraint *_constraintLblLanguagesHeight;
	UIImageView *_imagePoster;
	UILabel *_labelActorName;
	UILabel *_labelActors;
	UILabel *_labelAwards;
	UILabel *_labelAwardsName;
	UILabel *_labelDirectors;
	UILabel *_labelDirectorsName;
	UILabel *_labelGenre;
	UILabel *_labelGenreName;
	UILabel *_labelIMDBRating;
	UILabel *_labelIMDBRatingName;
	UILabel *_labelLanguage;
	UILabel *_labelLanguageName;
	UILabel *_labelReleaseDate;
	UILabel *_labelReleaseDateName;
	UILabel *_labelTitle;
}

@property (nonatomic, retain) IBOutlet NSLayoutConstraint *_constraintlblGenreHeight;
@property (retain, nonatomic) IBOutlet NSLayoutConstraint *constraintlblAwardsHeight;

@property (nonatomic, retain) IBOutlet UIButton *btnBack;

@property (nonatomic, retain) IBOutlet NSLayoutConstraint *constraintLblActorsHeight;

@property (nonatomic, retain) IBOutlet NSLayoutConstraint *constraintLblDirectorsHeight;

@property (nonatomic, retain) IBOutlet NSLayoutConstraint *constraintLblLanguagesHeight;

@property (nonatomic, retain) IBOutlet UIImageView *imagePoster;

@property (nonatomic, retain) IBOutlet UILabel *labelActorName;

@property (nonatomic, retain) IBOutlet UILabel *labelActors;

@property (nonatomic, retain) IBOutlet UILabel *labelAwards;

@property (nonatomic, retain) IBOutlet UILabel *labelAwardsName;

@property (nonatomic, retain) IBOutlet UILabel *labelDirectors;

@property (nonatomic, retain) IBOutlet UILabel *labelDirectorsName;

@property (nonatomic, retain) IBOutlet UILabel *labelGenre;

@property (nonatomic, retain) IBOutlet UILabel *labelGenreName;

@property (nonatomic, retain) IBOutlet UILabel *labelIMDBRating;

@property (nonatomic, retain) IBOutlet UILabel *labelIMDBRatingName;

@property (nonatomic, retain) IBOutlet UILabel *labelLanguage;

@property (nonatomic, retain) IBOutlet UILabel *labelLanguageName;

@property (nonatomic, retain) IBOutlet UILabel *labelReleaseDate;

@property (nonatomic, retain) IBOutlet UILabel *labelReleaseDateName;

@property (nonatomic, retain) IBOutlet UILabel *labelTitle;

- (IBAction)BackButton_TouchupInside:(UIButton *)sender;

@end
