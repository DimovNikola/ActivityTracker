import React from 'react';
import {SafeAreaView, View, Text, StyleSheet} from 'react-native';
import {TextInput, Button} from 'react-native-paper';

function CreateAccount({navigation}) {
  return (
    <SafeAreaView style={styles.container}>
      <View style={styles.cntr}>
        <View style={{width: '70%'}}>
          <Text>Username</Text>
          <TextInput />
          <Text>Password</Text>
          <TextInput />
        </View>
        <View
          style={{
            paddingTop: 100,
            justifyContent: 'space-around',
            flexDirection: 'row',
            alignItems: 'center',
            width: '100%',
          }}>
          <Button
            mode="contained"
            icon="arrow-left"
            contentStyle={{width: 100, height: 50}}
            labelStyle={{fontSize: 30, fontWeight: 'bold'}}
            onPress={() => navigation.navigate('SignIn')}></Button>
          <Button mode="contained" style={{backgroundColor: 'gray'}}>
            <Text>Register</Text>
          </Button>
        </View>
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#98D8AA',
    alignItems: 'center',
    justifyContent: 'center',
  },
  cntr: {
    flex: 1,
    alignItems: 'center',
    flexDirection: 'column',
    width: '100%',
    height: '80%',
    justifyContent: 'space-around',
  },
});

export default CreateAccount;
