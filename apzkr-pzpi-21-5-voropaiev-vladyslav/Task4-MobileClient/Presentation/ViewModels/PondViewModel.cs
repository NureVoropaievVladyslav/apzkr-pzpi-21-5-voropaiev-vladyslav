using System.Collections.ObjectModel;
using System.Windows.Input;
using Application.Abstractions.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Entities;
using Presentation.ViewModels.Base;

namespace Presentation.ViewModels;

public partial class PondViewModel : ViewModelBase
{
    private readonly IPondService _pondService;
    
    [ObservableProperty]
    private Pond? _currentEntity;
    // [ObservableProperty]
    // private TCreation? _newEntity = new TCreation();
    // [ObservableProperty]
    // private bool _isCreating = false;
    [ObservableProperty]
    private IEnumerable<Pond> _entities = new List<Pond>();
    
    public ICommand Loaded { get; set; }
    public ICommand GetEntities { get; set; }
    public ICommand GetEntity { get; set; }
    public ICommand Update { get; set; }
    // public ICommand Create { get; set; }
    // public ICommand ToCreate { get; set; }
    public ICommand BackToList { get; set; }

    public bool IsCurrentEntitySet => CurrentEntity is not null; //&& !IsCreating && ;
    public bool IsCurrentEntityNotSet => CurrentEntity is null; // !IsCreating && ;

    public PondViewModel(IPondService pondService)
    {
        _pondService = pondService;
        
        Loaded = new AsyncRelayCommand(LoadAsync);
        GetEntities = new AsyncRelayCommand(GetEntitiesAsync);
        GetEntity = new AsyncRelayCommand<SelectedItemChangedEventArgs>(GetCurrentEntityAsync);
        Update = new AsyncRelayCommand(UpdateAsync);
        // Create = new AsyncRelayCommand(CreateAsync);
        // ToCreate = new RelayCommand(ToCreatePage);
        BackToList = new AsyncRelayCommand(BackToListAsync);
    }
    
    partial void OnCurrentEntityChanged(Pond? oldValue, Pond? newValue)
    {
        OnPropertyChanged(nameof(IsCurrentEntitySet));
        OnPropertyChanged(nameof(IsCurrentEntityNotSet));
    }
    
    // partial void OnIsCreatingChanged(bool oldValue, bool newValue)
    // {
    //     OnPropertyChanged(nameof(IsCurrentEntitySet));
    //     OnPropertyChanged(nameof(IsCurrentEntityNotSet));
    // }
    
    private async Task GetEntitiesAsync()
    {
        Entities = await _pondService.GetPondsAsync(CancellationToken.None); 
    }
    
    protected virtual async Task GetCurrentEntityAsync(SelectedItemChangedEventArgs? args)
    {
        var entity = args?.SelectedItem as Pond;
    
        if (entity is null)
        {
            return;
        }
    
        CurrentEntity = entity;
    }
    
    protected virtual Task LoadAsync()
    {
        return GetEntitiesAsync();
    }
    
    protected virtual Task UpdateAsync()
    {
        return _pondService.UpdateScheduleAsync(CurrentEntity);
    }
    
    // protected virtual async Task CreateAsync()
    // {
    //     await _apiService.CreateAsync(NewEntity!); 
    //     await GetEntitiesAsync();
    //     IsCreating = false;
    // }
    //
    // private void ToCreatePage()
    // {
    //     NewEntity = new TCreation();
    //     IsCreating = true;
    // }
    
    private Task BackToListAsync()
    {
        CurrentEntity = null;
        return GetEntitiesAsync();
    }
}